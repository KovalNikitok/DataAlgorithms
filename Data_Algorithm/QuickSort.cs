using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class QuickSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
                return;

            RecursiveSort(collection, 0, collection.Count - 1);
        }

        public void RecursiveSort(IList<T> collection, int leftSideIndex, int rightSideIndex)
        {
            if (leftSideIndex >= rightSideIndex)
                return;

            // int pivotIndex = CalculatePivotIndex(leftSideIndex, rightSideIndex);
            // HoaraSorting(collection, leftSideIndex, rightSideIndex, pivotIndex);
            int pivotIndex = SortingWithPivot(collection, leftSideIndex, rightSideIndex);

            // Left side sort
            RecursiveSort(collection, leftSideIndex, pivotIndex - 1);
            // Right side sort
            RecursiveSort(collection, pivotIndex + 1, rightSideIndex);
        }

        // Unstable hoara algorithm
        private void HoaraSorting(IList<T> collection, int leftSideIndex, int rightSideIndex, int pivotIndex)
        {
            for (int leftIndex = leftSideIndex, rightIndex = rightSideIndex; ;)
            {
                while (leftIndex < pivotIndex && 
                        collection[leftIndex].CompareTo(collection[pivotIndex]) < 0)
                {
                    leftIndex++;
                }
                while (rightIndex > pivotIndex && 
                        collection[rightIndex].CompareTo(collection[pivotIndex]) >= 0)
                {
                    rightIndex--;
                }

                if (leftIndex >= pivotIndex && rightIndex <= pivotIndex)
                    break;
                Swap(collection, leftIndex, rightIndex);

                if (leftIndex < pivotIndex)
                    leftIndex++;
                if (rightIndex > pivotIndex)
                    rightIndex--;
            }
        }

        private int SortingWithPivot(IList<T> collection, int leftSideIndex, int rightSideIndex)
        {
            var pointer = leftSideIndex;

            for (int i = leftSideIndex; i <= rightSideIndex; i++)
            {
                if (collection[i].CompareTo(collection[rightSideIndex]) < 0)
                {
                    Swap(collection, pointer, i);
                    pointer++;
                }
            }
            Swap(collection, pointer, rightSideIndex);
            return pointer;
        }

            private int CalculatePivotIndex(int leftSideIndex, int rightSideIndex)
            => (leftSideIndex + rightSideIndex) / 2;
    }
}
