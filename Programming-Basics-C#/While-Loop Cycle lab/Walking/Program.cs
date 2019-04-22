using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalsteps = 0;
            int goal = 10000;

            while (true)
            {

                string command = Console.ReadLine();
                if (command == "Going home")
                {
                    int finalsteps = int.Parse(Console.ReadLine());
                    totalsteps += finalsteps;
                    break;
                }
                else
                {
                    int steps = int.Parse(command);
                    totalsteps += steps;
                }
                if (goal <= totalsteps) break;

            }
            if (goal>totalsteps) Console.WriteLine($"{10000-totalsteps} more steps to reach goal.");
            else Console.WriteLine("Goal reached! Good job!");
        }
    }
}
