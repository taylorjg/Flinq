using System;
using System.Collections.Generic;
using System.Linq;

namespace Flinq
{
    // I am deliberately using type parameters with names like A and B (as
    // opposed to TSource and TResult) to match the Scala methods.
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// LINQ query operators inspired by Scala
    /// </summary>
    public static class Enumerable
    {
        /// <summary>
        ///  Builds a new collection by applying a function to all elements of this list (same as Select).
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="B">The element type of the returned collection.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="f">The function to apply to each element.</param>
        /// <returns>The output sequence.</returns>
        public static IEnumerable<B> Map<A, B>(this IEnumerable<A> source,  Func<A, B> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            return source.Select(f);
        }

        /// <summary>
        /// Builds a new collection by applying a function to all elements of this list and using the elements of the resulting collections (same as SelectMany).
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="B">The element type of the returned collection.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="f">The function to apply to each element.</param>
        /// <returns>The output sequence.</returns>
        public static IEnumerable<B> FlatMap<A, B>(this IEnumerable<A> source, Func<A, IEnumerable<B>> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            return source.SelectMany(f);
        }

        /// <summary>
        /// Applies a binary operator to a start value and all elements of this list, going left to right.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="B">The type of the elements in the output sequence and the result type of the binary operator.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="z">The start value.</param>
        /// <param name="op">The binary operator.</param>
        /// <returns>The result of inserting <paramref name="op" /> between consecutive elements of this list, going left to right with the start value <paramref name="z" /> on the left.</returns>
        public static B FoldLeft<A, B>(this IEnumerable<A> source, B z, Func<B, A, B> op)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            return source.Aggregate(z, op);
        }

        /// <summary>
        /// Applies a binary operator to all elements of this list and a start value, going right to left.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="B">The type of the elements in the output sequence and the result type of the binary operator.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="z">The start value.</param>
        /// <param name="op">The binary operator.</param>
        /// <returns>The result of inserting <paramref name="op" /> between consecutive elements of this list, going right to left with the start value <paramref name="z" /> on the right.</returns>
        public static B FoldRight<A, B>(this IEnumerable<A> source, B z, Func<A, B, B> op)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            return source.Reverse().FoldLeft(z, (b, a) => op(a, b));
        }

        /// <summary>
        /// Applies a function f to all elements of this list.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="f">The function that is applied for its side-effect to every element.</param>
        public static void ForEach<A>(this IEnumerable<A> source, Action<A> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            foreach (var a in source) f(a);
        }

        /// <summary>
        /// Applies a function f to all elements of this list. Also passes an element index (int) to function f.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="f">The function that is applied for its side-effect to every element.</param>
        public static void ForEach<A>(this IEnumerable<A> source, Action<A, int> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            var index = 0;
            foreach (var a in source) f(a, index++);
        }

        /// <summary>
        /// Applies a function f to all elements of this list. Also passes an element index (long) to function f.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="f">The function that is applied for its side-effect to every element.</param>
        public static void ForEach<A>(this IEnumerable<A> source, Action<A, long> f)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (f == null) throw Error.ArgumentNull("f");

            var index = 0L;
            foreach (var a in source) f(a, index++);
        }

        /// <summary>
        /// Produces the range of all indices (int) of this sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <returns>A range of values from 0 to one less than the length of this list.</returns>
        public static IEnumerable<int> Indices<A>(this IEnumerable<A> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var index = 0;
            return source.Map(_ => index++);
        }

        /// <summary>
        /// Produces the range of all indices (long) of this sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <returns>A range of values from 0 to one less than the length of this list.</returns>
        public static IEnumerable<long> IndicesLong<A>(this IEnumerable<A> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var index = 0L;
            return source.Map(_ => index++);
        }

        /// <summary>
        /// Applies a binary operator to all elements of this sequence, going left to right.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="B">The type of the elements in the output sequence and the result type of the binary operator.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="op">The binary operator.</param>
        /// <returns>The result of inserting <paramref name="op" /> between consecutive elements of this sequence, going left to right.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the input sequence is empty.</exception>
        public static B ReduceLeft<A, B>(this IEnumerable<A> source, Func<B, A, B> op) where A : B
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                    throw Error.NoElements();

                B b = e.Current;

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
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <typeparam name="B">The type of the elements in the output sequence and the result type of the binary operator.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="op">The binary operator.</param>
        /// <returns>The result of inserting <paramref name="op" /> between consecutive elements of this sequence, going right to left.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the input sequence is empty.</exception>
        public static B ReduceRight<A, B>(this IEnumerable<A> source, Func<A, B, B> op) where A : B
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (op == null) throw Error.ArgumentNull("op");

            return source.Reverse().ReduceLeft<A, B>((b, a) => op(a, b));
        }

        /// <summary>
        /// Selects an interval of elements.
        /// </summary>
        /// <typeparam name="A">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="from">The index of the first element in the slice.</param>
        /// <param name="until">The index of one beyond the last element in the slice.</param>
        /// <returns>The output sequence.</returns>
        public static IEnumerable<A> Slice<A>(this IEnumerable<A> source, int from, int until)
        {
            if (source == null) throw Error.ArgumentNull("source");

            return source.Skip(from).Take(until - from);
        }

        /// <summary>
        /// Produces a new sequence where a slice of elements in this sequence is replaced by another sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements of source.</typeparam>
        /// <param name="source">The original sequence of elements.</param>
        /// <param name="from">The index of the first replaced element.</param>
        /// <param name="patch">The sequence of elements to replace a slice in the original sequence.</param>
        /// <param name="replaced">The number of elements to drop in the original sequence.</param>
        /// <returns>The output sequence.</returns>
        public static IEnumerable<A> Patch<A>(this IEnumerable<A> source, int from, IEnumerable<A> patch, int replaced)
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
        /// <typeparam name="A">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <returns><code>true</code> if the sequence contain no elements, <code>false</code> otherwise.</returns>
        public static bool IsEmpty<A>(this IEnumerable<A> source)
        {
            if (source == null) throw Error.ArgumentNull("source");

            return !source.Any();
        }

        /// <summary>
        /// Displays all elements of this sequence in a string.
        /// </summary>
        /// <typeparam name="A">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements to display.</param>
        /// <returns>A string representation of this sequence. In the resulting string the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence follow each other without any separator string.</returns>
        public static string MkString<A>(this IEnumerable<A> source)
        {
            return source.MkString(string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// Displays all elements of this sequence in a string using a separator string.
        /// </summary>
        /// <typeparam name="A">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements to display.</param>
        /// <param name="sep">The separator string.</param>
        /// <returns>A string representation of this sequence. In the resulting string the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence are separated by the string <paramref name="sep" />.</returns>
        public static string MkString<A>(this IEnumerable<A> source, string sep)
        {
            return source.MkString(string.Empty, sep, string.Empty);
        }

        /// <summary>
        /// Displays all elements of this sequence in a string using start, end, and separator strings.
        /// </summary>
        /// <typeparam name="A">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements to display.</param>
        /// <param name="start">The starting string.</param>
        /// <param name="sep">The separator string.</param>
        /// <param name="end">The ending string.</param>
        /// <returns>A string representation of this sequence. The resulting string begins with the string <paramref name="start" /> and ends with the string <paramref name="end" />. Inside, the string representations (w.r.t. the method <code>ToString</code>) of all elements of this sequence are separated by the string <paramref name="sep" />.</returns>
        public static string MkString<A>(this IEnumerable<A> source, string start, string sep, string end)
        {
            if (source == null) throw Error.ArgumentNull("source");

            var middle = string.Join(sep, source);
            return start + middle + end;
        }

        /// <summary>
        /// Tests whether this list starts with the given sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <returns><code>true</code> if this collection has <paramref name="that" /> as a prefix, <code>false</code> otherwise.</returns>
        internal static bool StartsWith<A>(this IEnumerable<A> source, IEnumerable<A> that)
        {
            return source.StartsWith(that, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Tests whether this list starts with the given sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns><code>true</code> if this collection has <paramref name="that" /> as a prefix, <code>false</code> otherwise.</returns>
        internal static bool StartsWith<A>(this IEnumerable<A> source, IEnumerable<A> that, IEqualityComparer<A> comparer)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (that == null) throw Error.ArgumentNull("that");

            using (var sourceEnumerator = source.GetEnumerator())
            {
                using (var thatEnumerator = that.GetEnumerator())
                {
                    for (; ; )
                    {
                        if (!thatEnumerator.MoveNext()) return true;
                        if (!sourceEnumerator.MoveNext()) return false;
                        if (!comparer.Equals(sourceEnumerator.Current, thatEnumerator.Current)) return false;
                    }
                }
            }
        }

        /// <summary>
        /// Tests whether this list ends with the given sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <returns><code>true</code> if this collection has <paramref name="that" /> as a suffix, <code>false</code> otherwise.</returns>
        internal static bool EndsWith<A>(this IEnumerable<A> source, IEnumerable<A> that)
        {
            return source.EndsWith(that, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Tests whether this list ends with the given sequence.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns><code>true</code> if this collection has <paramref name="that" /> as a suffix, <code>false</code> otherwise.</returns>
        internal static bool EndsWith<A>(this IEnumerable<A> source, IEnumerable<A> that, IEqualityComparer<A> comparer)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (that == null) throw Error.ArgumentNull("that");

            return source.Reverse().StartsWith(that.Reverse(), comparer);
        }

        /// <summary>
        /// Tests whether this list contains a given value as an element.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="elem">The element to test.</param>
        /// <returns><code>true</code> if this list has an element that is equal (as determined by the default comparer) to <paramref name="elem" />, <code>false</code> otherwise.</returns>
        internal static bool Contains<A>(this IEnumerable<A> source, A elem)
        {
            return source.Contains(elem, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Tests whether this list contains a given value as an element.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="elem">The element to test.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns><code>true</code> if this list has an element that is equal (as determined by <paramref name="comparer" />) to <paramref name="elem" />, <code>false</code> otherwise.</returns>
        internal static bool Contains<A>(this IEnumerable<A> source, A elem, IEqualityComparer<A> comparer)
        {
            if (source == null) throw Error.ArgumentNull("source");

            return source.Any(e => comparer.Equals(e, elem));
        }

        /// <summary>
        /// Tests whether this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <returns><code>true</code> if this list contains a slice with the same elements as <paramref name="that" />, otherwise <code>false</code>.</returns>
        internal static bool ContainsSlice<A>(this IEnumerable<A> source, IEnumerable<A> that)
        {
            return source.ContainsSlice(that, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Tests whether this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns><code>true</code> if this list contains a slice with the same elements as <paramref name="that" />, otherwise <code>false</code>.</returns>
        internal static bool ContainsSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, IEqualityComparer<A> comparer)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (that == null) throw Error.ArgumentNull("that");

            return source.IndexOfSlice(that, 0, comparer) >= 0;
        }

        /// <summary>
        /// Finds first index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <returns>The first index such that the elements of this list starting at this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int IndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that)
        {
            return source.IndexOfSlice(that, 0, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Finds first index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns>The first index such that the elements of this list starting at this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int IndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, IEqualityComparer<A> comparer)
        {
            return source.IndexOfSlice(that, 0, comparer);
        }

        /// <summary>
        /// Finds first index after or at a start index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="from">The start index.</param>
        /// <returns>The first index >= <paramref name="from" /> such that the elements of this list starting at this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int IndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, int from)
        {
            return source.IndexOfSlice(that, from, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Finds first index after or at a start index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="from">The start index.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns>The first index >= <paramref name="from" /> such that the elements of this list starting at this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int IndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, int from, IEqualityComparer<A> comparer)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (that == null) throw Error.ArgumentNull("that");

            // TODO: If source is indexable, then we could/should employ the Knuth–Morris–Pratt algorithm
            // http://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm

            // ReSharper disable PossibleMultipleEnumeration
            if (that.IsEmpty()) return 0;

            var index = from;
            var seq = source.Skip(from);
            for (; ; )
            {
                if (seq.IsEmpty()) return -1;
                if (seq.StartsWith(that, comparer)) return index;
                seq = seq.Tail();
                index++;
            }
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Finds last index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <returns>The last index such that the elements of this list starting a this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int LastIndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return source.LastIndexOfSlice(that, source.Count(), EqualityComparer<A>.Default);
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Finds last index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns>The last index such that the elements of this list starting a this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int LastIndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, IEqualityComparer<A> comparer)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return source.LastIndexOfSlice(that, source.Count(), comparer);
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Finds last index before or at a given end index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="end">The end index.</param>
        /// <returns>The last index &lt;= <paramref name="end" /> such that the elements of this list starting at this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int LastIndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, int end)
        {
            return source.LastIndexOfSlice(that, end, EqualityComparer<A>.Default);
        }

        /// <summary>
        /// Finds last index before or at a given end index where this list contains a given sequence as a slice.
        /// </summary>
        /// <typeparam name="A">The type of the elements in the input sequence.</typeparam>
        /// <param name="source">The input sequence.</param>
        /// <param name="that">The sequence to test.</param>
        /// <param name="end">The end index.</param>
        /// <param name="comparer">An <code>IEqualityComparer&lt;A&gt;</code> to use to compare elements.</param>
        /// <returns>The last index &lt;= <paramref name="end" /> such that the elements of this list starting at this index match the elements of sequence <paramref name="that" />, or -1 of no such subsequence exists.</returns>
        internal static int LastIndexOfSlice<A>(this IEnumerable<A> source, IEnumerable<A> that, int end, IEqualityComparer<A> comparer)
        {
            if (source == null) throw Error.ArgumentNull("source");
            if (that == null) throw Error.ArgumentNull("that");

            // ReSharper disable PossibleMultipleEnumeration
            var sourceLength = source.Count();
            var thatLength = that.Count();

            if (thatLength == 0) return sourceLength;

            var skipAmount = Math.Max(sourceLength - end - 1, 0);
            var reversedSource = source.Reverse().Skip(skipAmount);
            var result = reversedSource.IndexOfSlice(that.Reverse(), comparer);

            if (result >= 0)
            {
                result = sourceLength - thatLength - result - skipAmount;
            }

            return result;
            // ReSharper restore PossibleMultipleEnumeration
        }

        private static IEnumerable<A> Tail<A>(this IEnumerable<A> source)
        {
            return source.Skip(1);
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
