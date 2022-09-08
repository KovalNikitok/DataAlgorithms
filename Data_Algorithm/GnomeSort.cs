using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class GnomeSort<T> : Algorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
                return;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i].CompareTo(collection[i + 1]) <= 0)
                    continue;

                Swap(collection, i, i + 1);
                for (int j = i; j > 0; j--)
                {
                    if (collection[j].CompareTo(collection[j - 1]) > 0)
                        break;
                    Swap(collection, j, j - 1);
                }

            }
        }
    }
}
