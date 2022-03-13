using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{
    class Ex6
    {
        public Ex6()
        {
            string input = Console.ReadLine();
            string toReplace = Console.ReadLine();
            string newText = Console.ReadLine();
            string output = Regex.Replace(input, toReplace, newText);
            Console.WriteLine(output);
        }
    }
}
