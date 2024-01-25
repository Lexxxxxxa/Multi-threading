using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class WordFrequencyDictionary : ThreadsForArray<string>, IThreadsForArray
    {
        public ConcurrentDictionary<string, int> Frequency { get; private set; }

        public WordFrequencyDictionary(int threadCount, string[] enterArray) : base(threadCount, enterArray)
        {
            Frequency = new ConcurrentDictionary<string, int>();
        }

        protected override void ProcessElement(Span<string> span, int index, int threadIndex)
        {
            if (span[index] != null)
            {
                string word = span[index];
                Frequency.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
            }
        }
    }
}
