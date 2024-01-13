using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Multi_threading
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the size of the array: ");
            int arraySize = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of threads: ");
            int numThreads = int.Parse(Console.ReadLine());

            ArrayOperations arrayOps = new ArrayOperations(arraySize);
            TextOperations textOps = new TextOperations("This is a sample text for word frequency and character frequency.");

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numThreads; i++)
            {
                Thread thread = new Thread(() => PerformOperations(arrayOps, textOps));
                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        static void PerformOperations(ArrayOperations arrayOps, TextOperations textOps)
        {
            arrayOps.GenerateRandomArray();
            arrayOps.MinInArray();
            arrayOps.MaxInArray();
            arrayOps.SumOfArray();
            arrayOps.AverageOfArray();
            arrayOps.CopySubarray(1, 5);

            textOps.CharacterFrequency();
            textOps.WordFrequency();
        }
    }
}
