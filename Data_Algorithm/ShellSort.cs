using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class ShellSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            SwapTimes = 0;
            if (collection == null || collection.Count <= 1)
                return;
            int step = collection.Count / 2;
            while (step > 0)
            {
                for(int i = step; i < collection.Count; i++)
                {
                    for(int j = i - step; j >= 0; j -= step)
                    {
                        if (collection[j].CompareTo(collection[j + step]) > 0)
                            Swap(collection, j, j + step);
                    }
                }
                step /= 2;
            }
        }
    }
}
