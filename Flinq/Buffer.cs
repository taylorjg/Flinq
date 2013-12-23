using System;
using System.Collections.Generic;

namespace Flinq
{
    // Borrowed from RTMRel\ndp\fx\src\Core\System\Linq\Enumerable.cs\1407647\Enumerable.cs
    internal struct Buffer<TElement>
    {
        internal readonly TElement[] Items;
        internal readonly int Count;

        internal Buffer(IEnumerable<TElement> source)
        {
            TElement[] items = null;
            var count = 0;
            var collection = source as ICollection<TElement>;
            if (collection != null)
            {
                count = collection.Count;
                if (count > 0)
                {
                    items = new TElement[count];
                    collection.CopyTo(items, 0);
                }
            }
            else
            {
                foreach (var item in source)
                {
                    if (items == null)
                    {
                        items = new TElement[4];
                    }
                    else if (items.Length == count)
                    {
                        var newItems = new TElement[checked(count * 2)];
                        Array.Copy(items, 0, newItems, 0, count);
                        items = newItems;
                    }
                    items[count] = item;
                    count++;
                }
            }
            Items = items;
            Count = count;
        }
    }
}
