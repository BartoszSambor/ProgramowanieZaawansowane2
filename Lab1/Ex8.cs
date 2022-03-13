using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Ex8
    {
        public Ex8()
        {

        }
    }

    abstract class Contract
    {
        protected int salary;
        public abstract int Pensja();
        public Contract() {}
        public Contract(int salary)
        {
            this.salary = salary;
        }
    }

    class Intership : Contract
    {
        public override int Pensja()
        {
            return salary;
        }

        public Intership()
        {
            this.salary = 1000;
        }

        public Intership(int salary)
        {
            this.salary = salary;
        }
    }
    class FullTime : Contract
    {
        int overtime_hourly_rate;
        public override int Pensja()
        {
            return salary + overtime_hourly_rate * salary / 60;
        }

        public FullTime()
        {
            this.salary = 5000;
        }

        public FullTime(int salary, int overtime_hourly_rate)
        {
            this.salary = salary;
            this.overtime_hourly_rate = overtime_hourly_rate;
        }
    }

}
