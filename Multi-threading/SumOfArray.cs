using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class SumOfArray : ThreadsForArray<int>, IThreadsForArray
    {
        public long Result { get; private set; }
        private long[] threadSums;

        public SumOfArray(int threadCount, int[] enterArray) : base(threadCount, enterArray)
        {
            threadSums = new long[threadCount];
        }

        public override void ProcessAsync()
        {
            base.ProcessAsync();
            Result = threadSums.Sum();
        }

        protected override void ProcessElement(Span<int> span, int index, int threadIndex)
        {
            threadSums[threadIndex] += span[index];
        }
    }
}
