using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double p = double.Parse(Console.ReadLine()); 
            double h = double.Parse(Console.ReadLine());

            double totalweekends = 48;
            double totalweekendsinsofia = totalweekends-h;
            double playinsofia = totalweekendsinsofia * 3 / 4;
            double holidayplays = p * 2 / 3;
            double totalweekendplay = playinsofia + holidayplays+h;

            
            if (year=="leap")
            {
                Console.WriteLine(Math.Floor(totalweekendplay + (totalweekendplay * 0.15)));
            }
            else if (year=="normal")
            {
                Console.WriteLine(Math.Floor(totalweekendplay));
            }
        }
    }
}
