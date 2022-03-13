using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm f = new Farm();
            Console.WriteLine(f.LightestAnimal());
            Console.WriteLine(f.WaterNeeded());
            Console.WriteLine(f.HayNeeded());
        }
    }
}
