using System;
using System.Collections.Generic;
using System.Linq;

namespace Flinq
{
    public static class Enumerable
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source,  Func<TSource, TResult> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            return source.Select(f);
        }

        public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> source,  Func<TSource, IEnumerable<TResult>> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            return source.SelectMany(f);
        }

        public static TResult FoldLeft<TSource, TResult>(this IEnumerable<TSource> source, TResult z, Func<TResult, TSource, TResult> op)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            return source.Aggregate(z, op);
        }

        public static TResult FoldRight<TSource, TResult>(this IEnumerable<TSource> source, TResult z, Func<TSource, TResult, TResult> op)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            return FoldLeft(source.Reverse(), z, (b, a) => op(a, b));
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            foreach (var a in source) f(a);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            var index = 0;
            foreach (var a in source) f(a, index++);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, long> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            var index = 0L;
            foreach (var a in source) f(a, index++);
        }

        public static IEnumerable<int> Indices<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var index = 0;
            return source.Map(_ => index++);
        }

        public static IEnumerable<long> IndicesLong<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var index = 0L;
            return source.Map(_ => index++);
        }

        /// <summary>
        /// Applies a binary operator to all elements of this sequence, going left to right.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements in the output sequence and the result type of the binary operator.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="op">The binary operator.</param>
        /// <returns>The result of inserting op between consecutive elements of this sequence, going left to right.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the input sequence is empty.</exception>
        public static TResult ReduceLeft<TSource, TResult>(this IEnumerable<TSource> source, Func<TResult, TSource, TResult> op) where TSource : TResult
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                    throw Error.NoElements();

                TResult b = e.Current;

                for (; ; )
                {
                    if (!e.MoveNext()) break;
                    b = op(b, e.Current);
                }

                return b;
            }
        }

        /// <summary>
        /// Applies a binary operator to all elements of this sequence, going right to left.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements in the output sequence and the result type of the binary operator.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="op">The binary operator.</param>
        /// <returns>The result of inserting op between consecutive elements of this sequence, going right to left.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the input sequence is empty.</exception>
        public static TResult ReduceRight<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult, TResult> op) where TSource : TResult
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            return ReduceLeft<TSource, TResult>(source.Reverse(), (b, a) => op(a, b));
        }

        /// <summary>
        /// Selects an interval of elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="from">The index of the first element in the slice.</param>
        /// <param name="until">The index of one beyond the last element in the slice.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Slice<TSource>(this IEnumerable<TSource> source, int from, int until)
        {
            if (source == null) throw Error.ArgumentNull("source");

            return source.Skip(from).Take(until - from);
        }

        /// <summary>
        /// Produces a new sequence where a slice of elements in this sequence is replaced by another sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The original sequence of elements.</param>
        /// <param name="from">The index of the first replaced element.</param>
        /// <param name="patch">The sequence of elements to replace a slice in the original sequence.</param>
        /// <param name="replaced">The number of elements to drop in the original sequence.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Patch<TSource>(this IEnumerable<TSource> source, int from, IEnumerable<TSource> patch, int replaced)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (patch == null) throw Error.ArgumentNull("patch");

            using (var e = source.GetEnumerator())
            {
                for (; ; )
                {
                    if (from-- <= 0 || !e.MoveNext()) break;
                    yield return e.Current;
                }

                foreach (var thatElement in patch)
                    yield return thatElement;

                for (; ; )
                {
                    if (replaced-- <= 0) break;
                    if (!e.MoveNext()) yield break;
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
