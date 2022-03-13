using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Ex3
    {
        public Ex3()
        {
            Console.WriteLine("Exercise3");
            int size = int.Parse(Console.ReadLine());

            int[] input = Console
                .ReadLine()
                .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => int.Parse(item))
                .ToArray<int>();

            if (input.Min() == 1 && input.Max() == size && input.Length == size)
            {
                Console.WriteLine("TAK");
            }
            else
            {
                Console.WriteLine("NIE");
            }
        }
    }
}
