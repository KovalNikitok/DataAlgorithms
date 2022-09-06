using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms.DataAlgorithm
{
    public class AlgorithmDiagnostic<T> where T : IComparable<T>
    {
        private IList<T> _items { get; set; }
        private Algorithm<T> _algorithm { get; set; }
        public TimeSpan SortTime
        {
            get
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                _algorithm.Sort(_items);
                timer.Stop();
                var elapsed = timer.Elapsed;
                timer.Reset();
                return elapsed;
            }
        }
        public AlgorithmDiagnostic(Algorithm<T> algorithmType, IList<T> collection)
        {
            _algorithm = algorithmType;
            _items = collection;
        }

        public void ChangeCollection(IList<T> collection)
        {
            _items = collection;
        }

        public override string ToString()
        {
            var sortTimeMS = SortTime.Milliseconds;
            var swaps = _algorithm.SwapTimes;
            return $"With {swaps} swaps\n{sortTimeMS} ms elapsed for sorting\n"; ;
        }
    }
}
