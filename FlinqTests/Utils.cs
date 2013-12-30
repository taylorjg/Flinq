using System.Collections.Generic;
using System.Linq;

namespace FlinqTests
{
    internal static class Utils
    {
        public static IEnumerable<TSource> NullSequence<TSource>()
        {
            return null;
        }

        public static IEnumerable<TSource> EmptySequence<TSource>()
        {
            return Enumerable.Empty<TSource>();
        }

        public static IEnumerable<TSource> ToEnumerable<TSource>(this IEnumerable<TSource> source)
        {
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (var item in source) yield return item;
            // ReSharper restore LoopCanBeConvertedToQuery
        }
    }
}
