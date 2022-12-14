using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public abstract class Algorithm<T> where T : IComparable<T> 
    {
        public int SwapTimes { get; protected set; }
        protected virtual void Swap(IList<T> collection, int indexOfFirst, int indexOfSecond)
        {
            T temp = collection[indexOfFirst];
            collection[indexOfFirst] = collection[indexOfSecond];
            collection[indexOfSecond] = temp;
            SwapTimes++;
        }
        public abstract void Sort(IList<T> collection);
        public virtual int CompareTo(T other) => CompareTo(other);
    }
}
