﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Ex2
    {
        public Ex2()
        {
            Console.WriteLine("Exercise2");
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            while (input > 0)
            {
                sum += input % 10;
                input /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}