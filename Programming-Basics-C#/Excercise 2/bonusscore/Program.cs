using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonusscore
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            double bonuspoints = 0;

            if (points<=100)
            {
                bonuspoints += 5;
                
            }
            else if (points>100 && points<=1000)
            {
                bonuspoints += points * 0.2;
                                  
            }
            else if (points>1000)
            {
                bonuspoints += points * 0.1;
                
            }
            if (points % 10==5)
            {

                bonuspoints += 2;
            }
            if (points % 10==0)
            {
                bonuspoints += 1;
            }
            Console.WriteLine(bonuspoints);
            Console.WriteLine(points+bonuspoints);
        }
    }
}
