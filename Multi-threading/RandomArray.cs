using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class RandomArray<T> : ThreadsForArray<T>
    {
        private readonly Func<Random, T> randomize;
        private readonly ThreadLocal<Random> randoms;

        public RandomArray(int threadCount, T[] resultArray, Func<Random, T> rand) : base(threadCount, resultArray)
        {
            randomize = rand;
            randoms = new ThreadLocal<Random>(() => new Random());
        }

        public void ProcessAsync()
        {
            base.ProcessAsync();
        }

        protected override void ProcessElement(Span<T> span, int index, int threadIndex)
        {
            span[index] = randomize(randoms.Value);
        }
    }
}
