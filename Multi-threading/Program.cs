using System.Diagnostics;

namespace Multi_threading
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            int threadCount = 16;

            int[] intArr = new int[1_000_000];
            var intGen = new RandomArray<int>(threadCount, intArr, r => r.Next());
            intGen.ProcessAsync();

            char[] charArr = new char[1_000_000];
            var charGen = new RandomArray<char>(threadCount, charArr, r => (char)r.Next(32, 58));
            charGen.ProcessAsync();

            string[] strArr = new string[1_000_000];
            var wordArr = new string[] { "Zero", "One", "Two", "Three" };
            var strGen = new RandomArray<string>(threadCount, strArr, r => wordArr[r.Next(0, wordArr.Length)]);
            strGen.ProcessAsync();

            var maxProc = new MaxOfArray(threadCount, intArr);
            var minProc = new MinOfArray(threadCount, intArr);
            var sumProc = new SumOfArray(threadCount, intArr);
            var averageProc = new AverageArray(threadCount, intArr);
            var copyProc = new CopyArrayPart<int>(threadCount, intArr, new int[1785], 245, 1785);
            var charProc = new CharFrequencyDictionary(threadCount, charArr);
            var stringProc = new WordFrequencyDictionary(threadCount, strArr);

            IThreadsForArray[] processes = { maxProc, minProc, sumProc, averageProc, copyProc, charProc, stringProc };

            Print(processes);
        }

        private static async Task Print(IThreadsForArray[] processes)
        {
            foreach (var proc in processes)
            {
                var stopWatch = Stopwatch.StartNew();
                proc.ProcessAsync();
                stopWatch.Stop();
                Console.WriteLine($"Time of thread {stopWatch.Elapsed}");
            }
        }
    }
}