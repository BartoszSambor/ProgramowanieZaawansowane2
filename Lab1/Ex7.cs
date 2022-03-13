using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;

namespace Lab1
{
    class Ex7
    {
        public Ex7()
        {
            List<Student> students = new List<Student>();
            Console.WriteLine("Dodać studenta? t/n");
            string input = Console.ReadLine();
            while (input != "n")
            {
                Student s = Student.Load();
                students.Add(s);
                Console.WriteLine("Dodać studenta? t/n");
                input = Console.ReadLine();
            }
            foreach(Student s in students)
            {
                Console.WriteLine(s);
            }
        }
    }

    class Student
    {
        string field;
        int year;
        List<(string, string)> examsScore;

        public Student(string field, int year, List<(string, string)> examsScore)
        {
            this.field = field;
            this.year = year;
            this.examsScore = examsScore;
        }

        public static Student Load()
        {
            Console.WriteLine("Dodaj studenta: ");
            string field = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());

            List<(string, string)> l = new List<(string, string)>();
            string input = Console.ReadLine();
            while (input != String.Empty)
            {
                string[] t = input.Split();
                l.Add((t[0], t[1]));
                input = Console.ReadLine();
            }

            return new Student(field, year, l);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.Append(
                "Field: " + field
                + "\nYear: " + year
                + "\nExams score:\n"
                );

            foreach (var elem in examsScore)
            {
                sb.Append(String.Format("{0}: {1}\n", elem.Item1, elem.Item2));
            }

            return sb.ToString();
        }
    }

}
