using System.Collections.Generic;
using System.Linq;

namespace Flinq
{
    // ReSharper disable InconsistentNaming

    // https://github.com/scala/scala/blob/master/src/library/scala/collection/SeqLike.scala
    // http://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm

    internal static class KmpSearchUtilities
    {
        internal static int KmpSearch<B>(
            IEnumerable<B> s,
            int m0,
            int m1,
            IEnumerable<B> w,
            int n0,
            int n1,
            IEqualityComparer<B> comparer,
            bool forward)
        {
            if (comparer == null) comparer = EqualityComparer<B>.Default;

            if (n1 == n0 + 1)
            {
                return (forward)
                    ? ClipR(s.IndexOf(w.ElementAt(n0), m0, comparer), m1)
                    : ClipL(s.LastIndexOf(w.ElementAt(n0), m1 - 1, comparer), m0 - 1);
            }

            if (m1 - m0 == n1 - n0)
            {
                if (s.Slice(m0, m1).SequenceEqual(w.Slice(n0, n1), comparer))
                    return m0;
                return -1;
            }

            var list = s as IList<B>;
            if (list != null)
            {
                var wOpt = KmpOptimisedWord(w, n0, n1, forward);
                var jumpTable = KmpJumpTable(wOpt, n1 - n0, comparer);
                var i = 0;
                var m = 0;
                var zero = (forward) ? m0 : m1 - 1;
                var delta = (forward) ? 1 : -1;
                while (i + m < m1 - m0)
                {
                    if (comparer.Equals(wOpt[i], list[zero + delta * (i + m)]))
                    {
                        i++;
                        if (i == n1 - n0)
                        {
                            return (forward) ? m + m0 : m1 - m - i;
                        }
                    }
                    else
                    {
                        var ti = jumpTable[i];
                        m += i - ti;
                        if (i > 0)
                        {
                            i = ti;
                        }
                    }
                }
                return -1;
            }

            var it = s.Skip(m0);
            using (var e = it.GetEnumerator())
            {
                var wOpt = KmpOptimisedWord(w, n0, n1, forward: true);
                var jumpTable = KmpJumpTable(wOpt, n1 - n0, comparer);
                var cache = new B[n1 - n0];
                var largest = 0;
                var i = 0;
                var m = 0;
                var answer = -1;
                while (m + m0 + n1 - n0 <= m1)
                {
                    while (i + m >= largest)
                    {
                        e.MoveNext();
                        cache[largest % (n1 - n0)] = e.Current;
                        largest++;
                    }
                    if (comparer.Equals(wOpt[i], cache[(i + m) % (n1 - n0)]))
                    {
                        i++;
                        if (i == n1 - n0)
                        {
                            if (forward)
                            {
                                return m + m0;
                            }
                            i--;
                            answer = m + m0;
                            var ti = jumpTable[i];
                            m += i - ti;
                            if (i > 0)
                            {
                                i = ti;
                            }
                        }
                    }
                    else
                    {
                        var ti = jumpTable[i];
                        m += i - ti;
                        if (i > 0)
                        {
                            i = ti;
                        }
                    }
                }
                return answer;
            }
        }

        private interface IKmpOptimisedWord<out B>
        {
            int Length { get; }
            B this[int index] { get; }
        }

        private class KmpOptimisedWordV1<B> : IKmpOptimisedWord<B>
        {
            public KmpOptimisedWordV1(IList<B> iso)
            {
                _iso = iso;
            }

            public int Length
            {
                get { return _iso.Count; }
            }

            public B this[int index]
            {
                get { return _iso[index]; }
            }

            private readonly IList<B> _iso;
        }

        private class KmpOptimisedWordV2<B> : IKmpOptimisedWord<B>
        {
            public KmpOptimisedWordV2(IList<B> iso, int n0, int n1)
            {
                _iso = iso;
                _n0 = n0;
                _n1 = n1;
            }

            public int Length
            {
                get { return _n1 - _n0; }
            }

            public B this[int index]
            {
                get { return _iso[_n0 + index]; }
            }

            private readonly IList<B> _iso;
            private readonly int _n0;
            private readonly int _n1;
        }

        private class KmpOptimisedWordV3<B> : IKmpOptimisedWord<B>
        {
            public KmpOptimisedWordV3(IList<B> iso, int n0, int n1)
            {
                _iso = iso;
                _n0 = n0;
                _n1 = n1;
            }

            public int Length
            {
                get { return _n1 - _n0; }
            }

            public B this[int index]
            {
                get { return _iso[_n1 - 1 - index]; }
            }

            private readonly IList<B> _iso;
            private readonly int _n0;
            private readonly int _n1;
        }

        private class KmpOptimisedWordV4<B> : IKmpOptimisedWord<B>
        {
            public KmpOptimisedWordV4(IEnumerable<B> w, int n0, int n1, bool forward)
            {
                _n0 = n0;
                _n1 = n1;

                _arr = new B[n1 - n0];
                var wit = w.Skip(n0);
                using (var e = wit.GetEnumerator())
                {
                    var delta = (forward) ? 1 : -1;
                    var done = (forward) ? n1 - n0 : -1;
                    var i = (forward) ? 0 : n1 - n0 - 1;
                    while (i != done)
                    {
                        e.MoveNext();
                        _arr[i] = e.Current;
                        i += delta;
                    }
                }
            }

            public int Length
            {
                get { return _n1 - _n0; }
            }

            public B this[int index]
            {
                get { return _arr[index]; }
            }

            private readonly int _n0;
            private readonly int _n1;
            private readonly B[] _arr;
        }

        private static IKmpOptimisedWord<B> KmpOptimisedWord<B>(
            IEnumerable<B> w,
            int n0,
            int n1,
            bool forward)
        {
            var iso = w as IList<B>;
            if (iso != null)
            {
                if (forward && n0 == 0 && n1 == iso.Count)
                {
                    return new KmpOptimisedWordV1<B>(iso);
                }

                return (forward)
                    ? new KmpOptimisedWordV2<B>(iso, n0, n1) as IKmpOptimisedWord<B>
                    : new KmpOptimisedWordV3<B>(iso, n0, n1);
            }

            return new KmpOptimisedWordV4<B>(w, n0, n1, forward);
        }

        private static int[] KmpJumpTable<B>(IKmpOptimisedWord<B> wOpt, int wLen, IEqualityComparer<B> comparer)
        {
            var arr = new int[wLen];
            var pos = 2;
            var cnd = 0;
            arr[0] = -1;
            arr[1] = 0;

            while (pos < wLen)
            {
                if (comparer.Equals(wOpt[pos - 1], wOpt[cnd]))
                {
                    arr[pos] = cnd + 1;
                    pos++;
                    cnd++;
                }
                else if (cnd > 0)
                {
                    cnd = arr[cnd];
                }
                else
                {
                    arr[pos] = 0;
                    pos++;
                }
            }

            return arr;
        }

        private static int ClipR(int x, int y)
        {
            return (x < y) ? x : -1;
        }

        private static int ClipL(int x, int y)
        {
            return (x > y) ? x : -1;
        }
    }
}
