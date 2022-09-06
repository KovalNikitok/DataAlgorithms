using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class InsertionSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            SwapTimes = 0;
            if (collection == null || collection.Count <= 1)
                return;
            
            for(int i = 1, j; i < collection.Count; i++)
            {
                j = i;
                while (j > 0)
                {
                    if (collection[j].CompareTo(collection[j - 1]) < 0)
                        Swap(collection, j, j - 1);
                    j--;
                }
            }
        }
    }
}
