using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_threading
{
    class TextOperations
    {
        private readonly string text;
        private readonly object textLock = new object();

        public TextOperations(string inputText)
        {
            text = inputText;
        }

        public void CharacterFrequency()
        {
            lock (textLock)
            {
                var charFrequency = text.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
                Console.WriteLine($"Character frequency: {string.Join(", ", charFrequency)}");
            }
        }

        public void WordFrequency()
        {
            lock (textLock)
            {
                var words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                var wordFrequency = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
                Console.WriteLine($"Word frequency: {string.Join(", ", wordFrequency)}");
            }
        }
    }
}
