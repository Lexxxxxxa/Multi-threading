using System.Text;

namespace Multi_threading
{
    class TextOperations
    {
        private readonly string text;

        public TextOperations()
        {
            text = GenerateRandomText();
        }

        private string GenerateRandomText()
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();

            string chars = "abcdefghijklmnopqrstuvwxyz";
            int numWords = random.Next(100, 500);

            for (int i = 0; i < numWords; i++)
            {
                int wordLength = random.Next(3, 8);
                string word = new string(Enumerable.Repeat(chars, wordLength)
                                              .Select(s => s[random.Next(s.Length)]).ToArray());

                builder.Append(word + " ");
            }

            return builder.ToString().Trim();
        }

        public TextOperations(string inputText)
        {
            text = inputText;
        }

        public void CharacterFrequency()
        {
            var charFrequency = text.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Console.WriteLine($"Character frequency: {string.Join(", ", charFrequency)}");
        }

        public void WordFrequency()
        {
            var words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var wordFrequency = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
            Console.WriteLine($"Word frequency: {string.Join(", ", wordFrequency)}");
        }
    }
}
