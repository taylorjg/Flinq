using System;
using System.Collections.Generic;
using System.Linq;

namespace Flinq
{
    public static class Enumerable
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source,  Func<TSource, TResult> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            return source.Select(fn);
        }

        public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> source,  Func<TSource, IEnumerable<TResult>> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            return source.SelectMany(fn);
        }

        public static TResult FoldLeft<TSource, TResult>(this IEnumerable<TSource> source, TResult z, Func<TResult, TSource, TResult> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            return source.Aggregate(z, fn);
        }

        public static TResult FoldRight<TSource, TResult>(this IEnumerable<TSource> source, TResult z, Func<TSource, TResult, TResult> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            return FoldLeft(source.Reverse(), z, (b, a) => fn(a, b));
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            foreach (var a in source) fn(a);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            var index = 0;
            foreach (var a in source) fn(a, index++);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, long> fn)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            var index = 0L;
            foreach (var a in source) fn(a, index++);
        }

        public static IEnumerable<int> Indices<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var index = 0;
            return source.Select(_ => index++);
        }

        public static IEnumerable<long> IndicesLong<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var index = 0L;
            return source.Select(_ => index++);
        }

        public static TResult ReduceLeft<TSource, TResult>(this IEnumerable<TSource> source, Func<TResult, TSource, TResult> fn) where TSource : TResult
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                    throw Error.NoElements();

                var a = e.Current;
                TResult r = a;

                for (; ; )
                {
                    if (!e.MoveNext()) break;
                    r = fn(r, e.Current);
                }

                return r;
            }
        }

        public static TResult ReduceRight<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult, TResult> fn) where TSource : TResult
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (fn == null) throw Error.ArgumentNull("fn");

            return ReduceLeft<TSource, TResult>(source.Reverse(), (b, a) => fn(a, b));
        }

        public static IEnumerable<TSource> Slice<TSource>(this IEnumerable<TSource> source, int from, int until)
        {
            if (source == null) throw Error.ArgumentNull("source");

            return source.Skip(from).Take(until - from);
        }

        public static IEnumerable<TSource> Patch<TSource>(this IEnumerable<TSource> source, int from, IEnumerable<TSource> that, int replaced)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (that == null) throw Error.ArgumentNull("that");

            using (var e = source.GetEnumerator())
            {
                for (; ; )
                {
                    if (from <= 0) break;
                    if (!e.MoveNext()) break;
                    yield return e.Current;
                    from--;
                }

                foreach (var thatElement in that)
                    yield return thatElement;

                for (; ; )
                {
                    if (replaced <= 0) break;
                    if (!e.MoveNext()) yield break;
                    replaced--;
                }

                for (;;)
                {
                    if (!e.MoveNext()) yield break;
                    yield return e.Current;
                }
            }
        }

        /// <summary>
        /// Tests whether this sequence is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <returns><code>true</code> if the sequence contain no elements, <code>false</code> otherwise.</returns>
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            using (var e = source.GetEnumerator())
                return !e.MoveNext();
        }

        /// <summary>
        /// Displays all elements of this sequence in a string.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements to display.</param>
        /// <returns>A string representation of this sequence. In the resulting string the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence follow each other without any separator string.</returns>
        public static string MkString<TSource>(this IEnumerable<TSource> source)
        {
            return MkString(source, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// Displays all elements of this sequence in a string using a separator string.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements to display.</param>
        /// <param name="sep">The separator string.</param>
        /// <returns>A string representation of this sequence. In the resulting string the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence are separated by the string sep.</returns>
        public static string MkString<TSource>(this IEnumerable<TSource> source, string sep)
        {
            return MkString(source, string.Empty, sep, string.Empty);
        }

        /// <summary>
        /// Displays all elements of this sequence in a string using start, end, and separator strings.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements to display.</param>
        /// <param name="start">The starting string.</param>
        /// <param name="sep">The separator string.</param>
        /// <param name="end">The ending string.</param>
        /// <returns>A string representation of this sequence. The resulting string begins with the string start and ends with the string end. Inside, the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence are separated by the string sep.</returns>
        public static string MkString<TSource>(this IEnumerable<TSource> source, string start, string sep, string end)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var middle = string.Join(sep, source);
            return start + middle + end;
        }

        private static class Error
        {
            public static Exception ArgumentNull(string paramName)
            {
                return new ArgumentNullException(paramName);
            }

            public static Exception NoElements()
            {
                return new InvalidOperationException("Sequence contains no elements");
            }
        }
    }
}
