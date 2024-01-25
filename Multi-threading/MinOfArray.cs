using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class MinOfArray : ThreadsForArray<int>, IThreadsForArray
    {
        public int Result { get; private set; }
        private int[] threadMins;

        public MinOfArray(int threadCount, int[] enterArray) : base(threadCount, enterArray)
        {
            threadMins = new int[threadCount];
            Array.Fill(threadMins, int.MinValue);
        }

        public void ProcessAsync()
        {
            base.ProcessAsync();
            Result = threadMins.Min();
        }

        protected override void ProcessElement(Span<int> span, int index, int threadIndex)
        {
            if (span[index] < threadMins[threadIndex])
            {
                threadMins[threadIndex] = span[index];
            }
        }
    }
}
