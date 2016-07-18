using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyCounter
{
    /// <summary>
    /// Allows to calculate the frequency of occurrence of words in a text file.
    /// </summary>
    public sealed class Counter
    {
        /// <summary>
        /// Allows to get words frequency by dictionary. 
        /// </summary>
        public Dictionary<string, int> WordsFrequency => WordsCounter;

        /// <summary>
        /// Allows to calculate the frequency of occurrence of words in a text file.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public Counter(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Wrong file path or file doesn't exist.");

            StreamReader reader = null;
           
            reader = new StreamReader(path);
                 
            string[] words = reader.ReadToEnd().Split();

            WordsCounter = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (WordsCounter.ContainsKey(word))
                {
                    int counter;
                    WordsCounter.TryGetValue(word, out counter);
                    WordsCounter[word] = ++counter;
                }
                else
                    WordsCounter.Add(word, 1);
            }
        }

        private readonly Dictionary<string, int> WordsCounter;
    }
}
