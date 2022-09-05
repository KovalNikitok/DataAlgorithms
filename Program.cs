using DataAlgorithm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Algorithms
{
    class Program
    {
        static void Main()
        {
            var reversedCollection = new List<int>();
            var sortedCollection = new List<int>();
            var randomUnsortedCollection = new List<int>();

            // Files with reversed item at files:
            // reversed5000.txt, reversed10000.txt, reversed50000.txt (5k, 10k, 50k items)
            GetDataFromFile("reversed10000.txt", reversedCollection);

            // Files with sorted item at files:
            // sorted5000.txt, sorted10000.txt, sorted50000.txt (5k, 10k, 50k items)
            GetDataFromFile("sorted10000.txt", sortedCollection);

            // Files with random unsorted item at files:
            // random5000.txt, random10000.txt, random50000.txt (5k, 10k, 50k items)
            GetDataFromFile("random10000.txt", randomUnsortedCollection);

            Algorithm<int>[] algorithms = new Algorithm<int>[5];
            algorithms[0] = new BubbleSort<int>();

            
            SortAllCollectionWithResults_Console(algorithms,
                                                 reversedCollection,
                                                 sortedCollection,
                                                 randomUnsortedCollection);
        }

        private static void SortAllCollectionWithResults_Console(Algorithm<int>[] algorithms, List<int> reversedCollection, List<int> sortedCollection, List<int> randomUnsortedCollection)
        {
            foreach (var item in algorithms)
            {
                if (item == null)
                    continue;

                var newList = new int[reversedCollection.Count];
                Stopwatch timer = new Stopwatch();
                Console.WriteLine($"{item.GetType().Name} algorithm results:");

                reversedCollection.CopyTo(newList);
                timer.Start();
                item.Sort(newList);
                timer.Stop();
                Console.WriteLine($"Sort reversed collection for: {timer.Elapsed.TotalMilliseconds} ms");

                sortedCollection.CopyTo(newList);
                timer.Restart();
                item.Sort(newList);
                timer.Stop();
                Console.WriteLine($"Sort sorted collection for: {timer.Elapsed.TotalMilliseconds} ms");

                randomUnsortedCollection.CopyTo(newList);
                timer.Restart();
                item.Sort(newList);
                timer.Stop();
                Console.WriteLine($"Sort random unsorted collection for: {timer.Elapsed.TotalMilliseconds} ms");
                
                Console.WriteLine();
            }
        }

        private static void GetDataFromFile(string filename, List<int> collection)
        {
            if(string.IsNullOrWhiteSpace(filename))
                return;
            using (var file = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
            {
                var line = file.ReadLine();
                while (line != null)
                {
                    if (int.TryParse(line, out int item))
                        collection.Add(item);
                    line = file.ReadLine();
                }
            }
        }
    }

}

