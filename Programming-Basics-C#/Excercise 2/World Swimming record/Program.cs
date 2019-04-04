using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Swimming_record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double speed = double.Parse(Console.ReadLine());

            double time = distance * speed;
            double slowdown = Math.Floor(distance/15)*12.5;            
            double finaltime = time + slowdown;
            double timeneeded = finaltime - record;

            if (record<=finaltime)
            {
                Console.WriteLine($"No, he failed! He was {timeneeded:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {finaltime:F2} seconds.");
            }

        }
    }
}
