using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrequencyCounter;

namespace FrequencyCounterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter first = new Counter("Lorem ipsum.txt");
            foreach (var item in first.WordsFrequency)
            {
                Console.WriteLine(item);
            }
        }
    }
}
