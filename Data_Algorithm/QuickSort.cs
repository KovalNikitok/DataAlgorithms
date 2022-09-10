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

            //QuickSorting(collection, 0, collection.Count - 1);
            HoaraSorting(collection, 0, collection.Count - 1);
        }

        private void HoaraSorting(IList<T> collection, int firstIndex, int lastIndex)
        {
            int leftIndex = firstIndex;
            int rightIndex = lastIndex;
            T pivot = collection[CalculatePivotIndex(firstIndex, lastIndex)];

            do
            {
                while (collection[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                }
                while (collection[rightIndex].CompareTo(pivot) > 0)
                {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex)
                {
                    if (collection[leftIndex].CompareTo(collection[rightIndex]) > 0)
                        Swap(collection, leftIndex, rightIndex);

                    leftIndex++;
                    rightIndex--;
                }
            }
            while (leftIndex <= rightIndex);

            if (rightIndex > firstIndex)
                HoaraSorting(collection, firstIndex, rightIndex);

            if (leftIndex < lastIndex)
                HoaraSorting(collection, leftIndex, lastIndex);
        }

        public void QuickSorting(IList<T> collection, int leftSideIndex, int rightSideIndex)
        {
            if (leftSideIndex >= rightSideIndex)
                return;
            int pivotIndex = SortingWithPivot(collection, leftSideIndex, rightSideIndex);
            // Left side sort
            QuickSorting(collection, leftSideIndex, pivotIndex - 1);
            // Right side sort
            QuickSorting(collection, pivotIndex + 1, rightSideIndex);
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
