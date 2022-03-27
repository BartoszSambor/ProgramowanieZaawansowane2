using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Ex2
    {
        public Ex2()
        {/*
            Console.WriteLine("Exercise2");
            int input =int.Parse(Console.ReadLine());
            int sum = 0;
            while(input > 0)
            {
                sum += input % 10;
                input /= 10;
            }
            Console.WriteLine(sum);*/

            Console.WriteLine("Exercise4");
            int size = int.Parse(Console.ReadLine());
            int maxValue = int.Parse(Console.ReadLine());
            int maxDiff = 0;

            foreach(int i in Enumerable.Range(1, size))
            {
                int curr = int.Parse(Console.ReadLine());
                if (maxValue - curr > maxDiff)
                {
                    maxDiff = maxValue - curr;
                }
                if(curr > maxValue)
                {
                    maxValue = curr;
                }
                Console.WriteLine(maxValue + " | " + maxDiff);
            }
        }
    }
}
