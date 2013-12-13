using System.Collections.Generic;

namespace FlinqTests
{
    internal static class Utils
    {
        public static IEnumerable<TSource> NullSequence<TSource>()
        {
            return null;
        }
    }
}
