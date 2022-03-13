using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Ex1
    {
        public Ex1(int year)
        {
            Console.WriteLine("Exercise1");
            if (year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
            {
                Console.WriteLine("Przestępny");
            }
            else
            {
                Console.WriteLine("Nie przestępny");
            }
        }
    }
}
