using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    class ArrayOperations
    {
        private int[] array;
        private readonly object arrayLock = new object();

        public ArrayOperations(int size)
        {
            array = Enumerable.Range(1, size).Select(_ => new Random().Next(1, 100)).ToArray();
        }

        public void GenerateRandomArray()
        {
            lock (arrayLock)
            {
                Console.WriteLine($"Generated array: [{string.Join(", ", array)}]");
            }
        }

        public void MinInArray()
        {
            lock (arrayLock)
            {
                Console.WriteLine($"Min in array: {array.Min()}");
            }
        }

        public void MaxInArray()
        {
            lock (arrayLock)
            {
                Console.WriteLine($"Max in array: {array.Max()}");
            }
        }

        public void SumOfArray()
        {
            lock (arrayLock)
            {
                Console.WriteLine($"Sum of array: {array.Sum()}");
            }
        }

        public void AverageOfArray()
        {
            lock (arrayLock)
            {
                double average = array.Average();
                Console.WriteLine($"Average of array: {average}");
            }
        }

        public void CopySubarray(int start, int end)
        {
            lock (arrayLock)
            {
                int[] subarray = array.Skip(start).Take(end - start).ToArray();
                Console.WriteLine($"Copied subarray: [{string.Join(", ", subarray)}]");
            }
        }
    }
}
