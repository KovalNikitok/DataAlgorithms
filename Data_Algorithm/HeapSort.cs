using System;
using System.Collections.Generic;
using Algorithms.DataStructures;

namespace Algorithms.DataAlgorithm
{
    public class HeapSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            var binHeap = new BinaryHeap<T>(collection);
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                collection[i] = binHeap.PopMax();
            }
        }
    }
}
