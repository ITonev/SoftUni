using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeResults(double.Parse(Console.ReadLine()));
        }

        private static void GradeResults(double number)
        {
            if (number <= 2.99) Console.WriteLine("Fail");
            else if (number >= 3.00 && number <= 3.49) Console.WriteLine("Poor");
            else if (number >= 3.50 && number <= 4.49) Console.WriteLine("Good");
            else if (number >= 4.50 && number <= 5.49) Console.WriteLine("Very good");
            else Console.WriteLine("Excellent");
        }
    }
}
