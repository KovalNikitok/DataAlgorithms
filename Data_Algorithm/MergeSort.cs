using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class MergeSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
                return;

            var mergedCollection = RecursiveSort(collection, 0, collection.Count);
            for(int i = 0; i < mergedCollection.Count; i++)
            {
                collection[i] = mergedCollection[i];
            }
        }

        private IList<T> RecursiveSort(IList<T> collection, int startIndex, int countElements)
        {
            if (countElements < 2)
                return new T[] {collection[startIndex]};

            int halfElements = countElements / 2;
            var left = RecursiveSort(collection, startIndex, halfElements);

            var right = RecursiveSort(collection, 
                                      startIndex + halfElements, 
                                      countElements % 2 > 0 ? halfElements + 1 :
                                      halfElements);

            var result = new List<T>(left.Count + right.Count);
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                    continue;
                }

                result.Add(right[rightIndex]);
                rightIndex++;
            }

            while(leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }
    }
}
