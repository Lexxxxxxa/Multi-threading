using System.Diagnostics;

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
            TextOperations textOps = new TextOperations();

            Stopwatch stopwatch = Stopwatch.StartNew();

            PerformOperations(arrayOps, textOps, 0, arraySize);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static void PerformOperations(ArrayOperations arrayOps, TextOperations textOps, int start, int end)
        {
            arrayOps.FillArrayWithRandomData();

            Thread thread1 = new Thread(() => arrayOps.GenerateRandomArray(start, end));
            Thread thread2 = new Thread(() => arrayOps.MinInArray(start, end));
            Thread thread3 = new Thread(() => arrayOps.MaxInArray(start, end));
            Thread thread4 = new Thread(() => arrayOps.SumOfArray(start, end));
            Thread thread5 = new Thread(() => arrayOps.AverageOfArray(start, end));
            Thread thread6 = new Thread(() => arrayOps.CopySubarray(start, end));
            Thread thread7 = new Thread(() => textOps.CharacterFrequency());
            Thread thread8 = new Thread(() => textOps.WordFrequency());

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
            thread6.Join();
            thread7.Join();
            thread8.Join();
        }
    }
}