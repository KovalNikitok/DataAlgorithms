using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class SelectionSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
                return;

            for (int i = 0, minIndex; i < collection.Count - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                        minIndex = j;
                }
                Swap(collection, i, minIndex);  
            }
        }
    }
}
