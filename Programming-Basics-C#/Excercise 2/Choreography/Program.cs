using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            double percentperday = ((steps/days)/steps)*100;
            percentperday = Math.Ceiling(percentperday);
            double percentperdancer = percentperday / dancers;
            

            if (percentperday<=13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentperdancer:F2}%.");

            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {percentperdancer:F2}% steps to be learned per day.");
            }


        }
    }
}
