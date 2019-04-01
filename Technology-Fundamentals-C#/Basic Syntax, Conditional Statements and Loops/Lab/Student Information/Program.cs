using System;

namespace Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double studentGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}, Age: {studentAge}, Grade: {studentGrade:f2}");

        }
    }
}
