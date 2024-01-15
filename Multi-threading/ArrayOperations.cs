
namespace Multi_threading
{
    class ArrayOperations
    {
        private int[] array;
        private static readonly object lockObject = new object();
        private static readonly Random random = new Random();

        public void FillArrayWithRandomData()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
            }
            Console.WriteLine($"Array filled with random data: [{string.Join(", ", array)}]");
        }

        public ArrayOperations(int size)
        {
            array = Enumerable.Range(1, size).Select(_ => new Random().Next(1, 100)).ToArray();
        }

        public void GenerateRandomArray(int start, int end)
        {
            Console.WriteLine($"Generated array: [{string.Join(", ", array.Skip(start).Take(end - start))}]");
        }

        public void MinInArray(int start, int end)
        {
            Console.WriteLine($"Min in array: {array.Skip(start).Take(end - start).Min()}");
        }

        public void MaxInArray(int start, int end)
        {
            Console.WriteLine($"Max in array: {array.Skip(start).Take(end - start).Max()}");
        }

        public void SumOfArray(int start, int end)
        {
            Console.WriteLine($"Sum of array: {array.Skip(start).Take(end - start).Sum()}");
        }

        public void AverageOfArray(int start, int end)
        {
            double average = array.Skip(start).Take(end - start).Average();
            Console.WriteLine($"Average of array: {average}");
        }

        public void CopySubarray(int start, int end)
        {
            int[] subarray = array.Skip(start).Take(end - start).ToArray();
            Console.WriteLine($"Copied subarray: [{string.Join(", ", subarray)}]");
        }
    }
}
