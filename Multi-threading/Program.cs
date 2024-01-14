using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Multi_threading
{
    class Program
    {
        static void Main()
        {
            for (int arraySize = 1_000_000_000; arraySize >= 1_000; arraySize /= 10)
            {
                Console.WriteLine($"Array Size: {arraySize}");
                for (int numThreads = 1; numThreads <= Environment.ProcessorCount; numThreads++)
                {
                    var elapsedTime = MeasureExecutionTime(arraySize, numThreads);
                    Console.WriteLine($"Threads: {numThreads}, Time: {elapsedTime} ms");
                }
                Console.WriteLine();
            }
        }

        static long MeasureExecutionTime(int arraySize, int numThreads)
        {
            ArrayOperations arrayOps = new ArrayOperations(arraySize);
            TextOperations textOps = new TextOperations("This is a sample text for word frequency and character frequency.");

            Stopwatch stopwatch = Stopwatch.StartNew();

            Parallel.ForEach(Partitioner.Create(0, arraySize), new ParallelOptions { MaxDegreeOfParallelism = numThreads }, (range, state) =>
            {
                PerformOperations(arrayOps, textOps, range.Item1, range.Item2);
            });

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static void PerformOperations(ArrayOperations arrayOps, TextOperations textOps, int start, int end)
        {
            arrayOps.GenerateRandomArray(start, end);
            arrayOps.MinInArray(start, end);
            arrayOps.MaxInArray(start, end);
            arrayOps.SumOfArray(start, end);
            arrayOps.AverageOfArray(start, end);
            arrayOps.CopySubarray(start, end);

            textOps.CharacterFrequency();
            textOps.WordFrequency();
        }
    }
}
