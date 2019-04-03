using System;
using System.Globalization;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();

            DateTime dayOfWeek = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);

            string currentDay = dayOfWeek.DayOfWeek.ToString();
            Console.WriteLine(currentDay);

        }
    }
}
