using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab1
{
    class Ex4
    {
        public Ex4()
        {
            Console.WriteLine("Exercise4");
            int size = int.Parse(Console.ReadLine());
            int maxValue = int.Parse(Console.ReadLine());
            int maxDiff = 0;

            foreach (int i in Enumerable.Range(1, size))
            {
                int curr = int.Parse(Console.ReadLine());
                if (maxValue - curr > maxDiff)
                {
                    maxDiff = maxValue - curr;
                }
                if (curr > maxValue)
                {
                    maxValue = curr;
                }
            }
            Console.WriteLine(maxDiff);

        }
    }
}
