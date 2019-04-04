using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double brotherA = double.Parse(Console.ReadLine());
            double brotherB = double.Parse(Console.ReadLine());
            double brotherC = double.Parse(Console.ReadLine());
            double fatherfishing = double.Parse(Console.ReadLine());

            double cleaningtime = 1 / (1/brotherA + 1/brotherB + 1/brotherC);
            double cleaningbreak = cleaningtime * 0.15;
            cleaningtime = cleaningtime + cleaningbreak;

            Console.Write("Cleaning time: ");
            Console.WriteLine($"{cleaningtime:F2}");

            if (cleaningtime<=fatherfishing)
            {
                double timeleft = fatherfishing - cleaningtime;
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeleft)} hours.");
            }
            else
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(cleaningtime-fatherfishing)} hours.");
            }
        }
    }
}
