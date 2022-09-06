using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class ShakeSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override int CompareTo(T other) => CompareTo(other);

        public override void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
                return;
            Shake(collection);
        }

        private void Shake(IList<T> collection)
        {
            int leftIndex = 0;
            int rightIndex = collection.Count - 1;
            int i;
            int j;
            while (leftIndex < rightIndex)
            {
                i = leftIndex;
                while (i < rightIndex)
                {   
                    if (collection[i].CompareTo(collection[i + 1]) > 0)
                        Swap(collection, i, i + 1);
                    i++;
                }
                rightIndex--;

                j = rightIndex;
                while (j > leftIndex)
                {
                    if (collection[j].CompareTo(collection[j - 1]) < 0)
                        Swap(collection, j, j - 1);
                    j--;
                }
                leftIndex++;
            }
        }
    }
}
