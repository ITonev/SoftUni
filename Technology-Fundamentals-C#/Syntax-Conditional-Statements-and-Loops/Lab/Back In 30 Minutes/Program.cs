using System;

namespace Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {

            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes + 30 < 59)
            {
                Console.WriteLine($"{hours}:{minutes + 30}");
            }

            else
            {
                hours++;
                minutes = minutes - 30;

                if (hours>23)
                {
                    hours = 0;
                }

                if (minutes < 10)
                {
                    Console.WriteLine($"{hours}:0{minutes}");

                }
                else
                {
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }
        }
    }
}
