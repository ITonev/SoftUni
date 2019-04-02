using System;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 7)
            {
                Console.WriteLine("Invalid day!");
            }

            else
            {
                string[] daysOfWeek = new string[] {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
                };

                Console.WriteLine(daysOfWeek[number - 1]);
            }
        }
    }
}
