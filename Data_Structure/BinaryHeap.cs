using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    class BinaryHeap<T> : IEnumerable where T : IComparable<T>
    {
        private List<T> _items;
        public int Count => _items.Count;
        public BinaryHeap() 
        {
            _items = new List<T>();
        }
        public BinaryHeap(IList<T> items)
        {
            _items = new List<T>(items?.Count ?? 0);
            if (items.Count > 0)
            {
                _items.AddRange(items);
                for (int i = Count; i >= 0; i--)
                {
                    Sort(i);
                }
            }
        }
        public void Push(T item)
        {
            _items.Add(item);
            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);
            if (Count <= 0)
                return;

            while (currentIndex > 0 && _items[currentIndex].CompareTo(_items[parentIndex]) > 0)
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public T PopMax()
        {
            if (Count < 1)
                return default(T);
            var result = _items[0];
            _items[0] = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            if (Count > 0)
                Sort(0);
            return result;
        }

        public void Sort(int currentIndex)
        {
            var maxIndex = currentIndex;
            int leftIndex;
            int rightIndex;

            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;

                if (leftIndex < Count && _items[maxIndex].CompareTo(_items[leftIndex]) < 0)
                    maxIndex = leftIndex;
                if (rightIndex < Count && _items[maxIndex].CompareTo(_items[rightIndex]) < 0)
                    maxIndex = rightIndex;

                if (maxIndex == currentIndex)
                    break;

                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        private void Swap(int currentIndex, int nextIndex)
        {
            
            var temp = _items[currentIndex];
            _items[currentIndex] = _items[nextIndex];
            _items[nextIndex] = temp;
        }
        private int GetParentIndex(int currentIndex) => (currentIndex - 1) / 2;

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            for (int i = Count; i > 0; i--)
            {
                yield return PopMax();
            }
        }
    }
}
