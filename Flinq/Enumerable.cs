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
        public static TResult FoldLeft<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TResult, TSource, TResult> fn)
        {
            return source.Aggregate(seed, fn);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult FoldRight<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TSource, TResult, TResult> fn)
        {
            return source.Reverse().Aggregate(seed, (b, a) => fn(a, b));
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
    }
}
