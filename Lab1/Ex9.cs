using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Ex9
    {

    }

    class Farm
    {
        List<Mammal> animals = new List<Mammal>();
        public Farm()
        {
            animals.Add(new Cow());
            animals.Add(new Cow());
            animals.Add(new Cow());
            animals.Add(new Sheep());
            animals.Add(new Cat());
            animals.Add(new Cat());
        }

        public int WaterNeeded()
        {
            int sum = 0;
            foreach(Mammal m in animals)
            {
                sum += m.DrinkWater();
            }
            return sum;
        }

        public int HayNeeded()
        {
            int sum = 0;
            foreach (Mammal m in animals)
            {
                if(m is IEatHay hayEater)
                {
                    sum += hayEater.EatHay();
                }
            }
            return sum;
        }

        public int LightestAnimal()
        {
            int min = animals[0].CheckWeight();
            foreach (Mammal m in animals)
            {
                min = Math.Min(min, m.CheckWeight());
            }
            return min;
        }
    }

    abstract class Mammal
    {
        public abstract int CheckWeight();
        public abstract int DrinkWater(); 
    }

    interface IEatHay
    {
        public int EatHay();
    }
    class Cow : Mammal, IEatHay
    {
        public override int CheckWeight()
        {
            return 100;
        }
        public override int DrinkWater()
        {
            return 10;
        }
        public int EatHay()
        {
            return 30;
        }
    }
    class Sheep : Mammal, IEatHay
    {
        public override int CheckWeight()
        {
            return 50;
        }
        public override int DrinkWater()
        {
            return 6;
        }
        public int EatHay()
        {
            return 20;
        }

    }

    class Cat : Mammal
    {
        public override int CheckWeight()
        {
            return 5;
        }
        public override int DrinkWater()
        {
            return 1;
        }

        public int EatEverythingExcetWater()
        {
            return 2;
        }
    }


}
