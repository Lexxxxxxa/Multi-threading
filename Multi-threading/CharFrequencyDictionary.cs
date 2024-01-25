using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class CharFrequencyDictionary : ThreadsForArray<char>, IThreadsForArray
    {
        public ConcurrentDictionary<char, int> Result { get; private set; }

        public CharFrequencyDictionary(int threadCount, char[] enterArray) : base(threadCount, enterArray)
        {
            Result = new ConcurrentDictionary<char, int>();
        }

        protected override void ProcessElement(Span<char> span, int index, int threadIndex)
        {
            Result.AddOrUpdate(span[index], 1, (key, oldValue) => oldValue + 1);
        }
    }
}
