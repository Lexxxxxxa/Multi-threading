using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class AverageArray : ThreadsForArray<int>, IThreadsForArray
    {
        public double Result { get; private set; }
        private long[] threadSums;
        private int totalElements;

        public AverageArray(int threadCount, int[] enterArray) : base(threadCount, enterArray)
        {
            threadSums = new long[threadCount];
            totalElements = enterArray.Length;
        }

        public override void ProcessAsync()
        {
            base.ProcessAsync();
            Result = threadSums.Sum() / (double)totalElements;
        }

        protected override void ProcessElement(Span<int> span, int index, int threadIndex)
        {
            threadSums[threadIndex] += span[index];
        }
    }
}
