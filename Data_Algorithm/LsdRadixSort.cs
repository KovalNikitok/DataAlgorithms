using System;
using System.Collections.Generic;

namespace Algorithms.DataAlgorithm
{
    public class LsdRadixSort : Algorithm<int>
    {
        public override void Sort(IList<int> collection)
        {
            if (collection == null || collection.Count <= 1)
                return;
            foreach (var item in collection)
            {
                if (item < 0)
                    throw new ArgumentException("Numbers in collection is lesser then null.", $"{typeof(LsdRadixSort)}");
            }


            var buckets = new List<List<int>>(10);
            for (int i = 0; i < buckets.Capacity; i++)
            { 
                buckets.Add(new List<int>());
            }

            int length = MaxLength(collection);
            for (int iter = 0; iter < length; iter++)
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    buckets[GetBucketIndex(collection[i], iter)].Add(collection[i]);
                }

                collection.Clear();
                for(int i = 0; i < buckets.Count; i++)
                {
                    for (int j = 0; j < buckets[i].Count; j++)
                    {
                        collection.Add(buckets[i][j]);
                    }
                }

                for (int i = 0; i < buckets.Count; i++)
                {
                    buckets[i].Clear();
                }
            }
        }

        private static int GetBucketIndex(int item, int length)
        {
            var res = item % (int)Math.Pow(10, length + 1) / (int)Math.Pow(10, length);
            return res;
        }

        private int MaxLength(IList<int> numbers)
        {
            int max = 0;
            for (int i = 0, length = 0, number; i < numbers.Count; i++)
            {
                number = numbers[i];
                do
                {
                    number /= 10;
                    length++;
                }
                while (number != 0);

                if (max < length)
                    max = length;

                length = 0;
            }
            return max;
        }
    }
}
