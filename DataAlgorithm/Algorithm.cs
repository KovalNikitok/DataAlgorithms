using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public abstract class Algorithm<T> where T : IComparable<T> 
    {
        protected virtual void Swap(ref T first,ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        public abstract void Sort(IList<T> collection);
        public abstract int CompareTo(T other);
    }
}
