using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class MaxOfArray : ThreadsForArray<int>, IThreadsForArray
    {
        public int Result { get; private set; }
        private int[] threadMaxs;

        public MaxOfArray(int threadCount, int[] enterArray) : base(threadCount, enterArray)
        {
            threadMaxs = new int[threadCount];
            Array.Fill(threadMaxs, int.MaxValue);
        }

        public override void ProcessAsync()
        {
            base.ProcessAsync();
            Result = threadMaxs.Max();
        }

        protected override void ProcessElement(Span<int> span, int index, int threadIndex)
        {
            if (threadMaxs[threadIndex] <= span[index])
            {
                threadMaxs[threadIndex] = span[index];
            }
        }
    }
}
