using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{
    class Ex5
    {
        public Ex5()
        {
            string input = Console.ReadLine().ToLower();
            input = Regex.Replace(input, "[^a-z]", String.Empty);
            Dictionary<char, int> stats = new Dictionary<char, int>();
            foreach(char c in input)
            {
                int oldValue;
                bool hasKey = stats.TryGetValue(c, out oldValue);
                if(hasKey)
                    stats[c] = oldValue + 1;
                else
                    stats.Add(c, 1);
            }
            foreach (var pair in stats)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
    }
}
