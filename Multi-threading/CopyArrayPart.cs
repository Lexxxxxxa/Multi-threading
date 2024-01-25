using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class CopyArrayPart<T> : ThreadsForArray<T>, IThreadsForArray
    {
        private T[] destinationArray;
        private int copyStartIndex;
        private int copyLength;

        public CopyArrayPart(int threadCount, T[] sourceArray, T[] destinationArray, int copyStartIndex, int copyLength) : base(threadCount, sourceArray)
        {
            this.destinationArray = destinationArray;
            this.copyStartIndex = copyStartIndex;
            this.copyLength = copyLength;
        }

        protected override void ProcessElement(Span<T> span, int index, int threadIndex)
        {
            if (index >= copyStartIndex && index < copyStartIndex + copyLength)
            {
                destinationArray[index - copyStartIndex] = span[index];
            }
        }
    }
}
