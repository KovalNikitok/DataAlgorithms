using System;
using System.Collections.Generic;
namespace Algorithms.DataAlgorithm
{
    public class BubbleSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override int CompareTo(T other) => this.CompareTo(other);

        public override void Sort(IList<T> collection)
        {
            if (collection == null)
                return;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - i - 1; j++)
                {
                    var currentItem = collection[j];
                    var nextItem = collection[j + 1];

                    if (currentItem.CompareTo(nextItem) <= 0)
                        continue;
                    Swap(ref currentItem, ref nextItem);
                }
            }
        }

    }
}
