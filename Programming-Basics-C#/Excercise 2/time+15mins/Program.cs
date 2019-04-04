using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_15mins
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 15;

            if (minutes>59)
            {
                hours += 1;
                minutes = minutes - 60;
                
            }
            if (hours>23)
            {
                hours = 0;
            }
            if (minutes<10)
            {
                Console.WriteLine(hours+":0"+minutes);
            }
            else
            {
                Console.WriteLine(hours + ":" + minutes);
            }

            DateTime in15min = DateTime.ParseExact($"{hours}:{minutes}", "h:mm",null);
            in15min = in15min.AddMinutes(15);
            Console.WriteLine(in15min.ToString("h:mm"));
            // "h.mm" - 12 hour format
            // "H.mm" - 24 hour format
            // "h.mm tt" - 12 hour format + AM or PM
        }
    }
}
