using Algorithms.DataAlgorithm;
using System;
using System.Collections.Generic;
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
            GetDataFromFile("reversed5000.txt", reversedCollection);

            // Files with sorted item at files:
            // sorted5000.txt, sorted10000.txt, sorted50000.txt (5k, 10k, 50k items)
            GetDataFromFile("sorted5000.txt", sortedCollection);

            // Files with random unsorted item at files:
            // random5000.txt, random10000.txt, random50000.txt (5k, 10k, 50k items)
            GetDataFromFile("random5000.txt", randomUnsortedCollection);

            Algorithm<int>[] algorithms = new Algorithm<int>[10];
            algorithms[0] = new BubbleSort<int>();
            algorithms[1] = new ShakeSort<int>();
            algorithms[2] = new InsertionSort<int>();
            algorithms[3] = new ShellSort<int>();
            algorithms[4] = new HeapSort<int>();
            algorithms[5] = new TreeSort<int>();
            algorithms[6] = new SelectionSort<int>();
            algorithms[7] = new GnomeSort<int>();
            algorithms[8] = new LsdRadixSort();

            SortAllCollectionWithResults_Console(algorithms,
                                                 reversedCollection,
                                                 sortedCollection,
                                                 randomUnsortedCollection);
        }

        private static void SortAllCollectionWithResults_Console(Algorithm<int>[] algorithms, List<int> reversedCollection, List<int> sortedCollection, List<int> randomUnsortedCollection)
        {
            AlgorithmDiagnostic<int> algorithmDiagnostic;
            foreach (var item in algorithms)
            {
                if (item == null)
                    continue;

                var newList = new int[reversedCollection.Count];
                Console.WriteLine($"{item.GetType().Name[0..^2]} algorithm results:");

                reversedCollection.CopyTo(newList);
                algorithmDiagnostic = new AlgorithmDiagnostic<int>(item, newList);
                Console.WriteLine($"Sort reversed collection:\n{algorithmDiagnostic}");

                sortedCollection.CopyTo(newList);
                algorithmDiagnostic.ChangeCollection(newList);
                Console.WriteLine($"Sort sorted collection:\n{algorithmDiagnostic}");

                randomUnsortedCollection.CopyTo(newList);
                algorithmDiagnostic.ChangeCollection(newList);
                Console.WriteLine($"Sort random unsorted collection:\n{algorithmDiagnostic}");
                
                Console.WriteLine("\n");
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

