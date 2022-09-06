using System;
using System.Collections.Generic;
namespace Algorithms.DataAlgorithm
{
    public class BubbleSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            SwapTimes = 0;
            if (collection == null || collection.Count <= 1)
                return;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - i - 1; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) <= 0)
                        continue;
                    Swap(collection, j, j + 1);
                }
                if (SwapTimes == 0)
                    break;
            }
        }

    }
}
