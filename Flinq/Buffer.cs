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

        internal Buffer(IEnumerable<TElement> source, int end)
        {
            TElement[] items = null;
            var count = 0;

            var collection = source as ICollection<TElement>;
            if (collection != null && (collection.Count == 0 || end >= (collection.Count - 1)))
            {
                count = collection.Count;
                if (count > 0)
                {
                    items = new TElement[count];
                    collection.CopyTo(items, 0);
                }
                Items = items;
                Count = count;
                return;
            }

            var array = source as TElement[];
            if (array != null)
            {
                count = Math.Min(array.GetLength(0), Math.Max(end + 1, 0));
                if (count > 0)
                {
                    items = new TElement[count];
                    Array.Copy(array, 0, items, 0, count);
                }
                Items = items;
                Count = count;
                return;
            }

            foreach (var item in source)
            {
                if (end < 0) break;
                end--;

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

            Items = items;
            Count = count;
        }
    }
}
