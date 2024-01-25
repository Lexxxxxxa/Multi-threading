using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public abstract class ThreadsForArray<T>
    {
        protected readonly Thread[] threads;
        public readonly T[] result;

        public ThreadsForArray(int threadCount, T[] resultArray)
        {
            threads = new Thread[threadCount];
            result = resultArray;
        }

        public virtual void ProcessAsync()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = CreateThreadForIndex(i);
                threads[i].Start(i);
            }

            WaitForAllThreads();
        }

        private Thread CreateThreadForIndex(int index)
        {
            var thread = new Thread(ThreadProc) { IsBackground = true };
            return thread;
        }

        private void WaitForAllThreads()
        {
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        protected virtual void ThreadProc(object threadState)
        {
            int threadIndex = (int)threadState;
            int segmentSize = result.Length / threads.Length;

            int start = threadIndex * segmentSize;
            int end = threadIndex == threads.Length - 1 ? result.Length : start + segmentSize;

            Span<T> segment = result.AsSpan(start..end);

            for (int i = 0; i < segment.Length; i++)
            {
                ProcessElement(segment, i, threadIndex);
            }
        }

        protected abstract void ProcessElement(Span<T> segment, int index, int threadIndex);
    }
}
