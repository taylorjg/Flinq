using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Flinq
{
    public static class Enumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source,  Func<TSource, TResult> fn)
        {
            return source.Select(fn);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> source,  Func<TSource, IEnumerable<TResult>> fn)
        {
            return source.SelectMany(fn);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult FoldLeft<TSource, TResult>(this IEnumerable<TSource> source, TResult z, Func<TResult, TSource, TResult> fn)
        {
            return source.Aggregate(z, fn);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult FoldRight<TSource, TResult>(this IEnumerable<TSource> source, TResult z, Func<TSource, TResult, TResult> fn)
        {
            return FoldLeft(source.Reverse(), z, (b, a) => fn(a, b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> fn)
        {
            foreach (var a in source) fn(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> fn)
        {
            var index = 0;
            foreach (var a in source) fn(a, index++);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, long> fn)
        {
            var index = 0L;
            foreach (var a in source) fn(a, index++);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<int> Indices<TSource>(this IEnumerable<TSource> source)
        {
            var index = 0;
            return source.Select(_ => index++);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<long> IndicesLong<TSource>(this IEnumerable<TSource> source)
        {
            var index = 0L;
            return source.Select(_ => index++);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ReduceLeft<TSource, TResult>(this IEnumerable<TSource> source, Func<TResult, TSource, TResult> fn) where TSource : TResult
        {
            var e = source.GetEnumerator();

            if (!e.MoveNext())
            {
                throw new ArgumentException("Sequence is empty.", "source");
            }

            var a = e.Current;
            TResult r = a;

            for (; ; )
            {
                if (!e.MoveNext())
                {
                    break;
                }

                r = fn(r, e.Current);
            }

            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ReduceRight<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult, TResult> fn) where TSource : TResult
        {
            return ReduceLeft<TSource, TResult>(source.Reverse(), (b, a) => fn(a, b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            IEnumerator<TSource> _;
            TSource __;
            return IsEmpty(source, out _, out __);
        }

        private static bool IsEmpty<TSource>(IEnumerable<TSource> source, out IEnumerator<TSource> enumerator, out TSource head)
        {
            enumerator = source.GetEnumerator();
            var isEmpty = !enumerator.MoveNext();
            head = (isEmpty) ? default(TSource) : enumerator.Current;
            return isEmpty;
        }
    }
}
