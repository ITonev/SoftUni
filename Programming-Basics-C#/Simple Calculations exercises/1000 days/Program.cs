using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _1000_days
{
    class Program
    {
        static void Main(string[] args)
        {            
            string bday = Console.ReadLine();
            DateTime final = DateTime.ParseExact(bday, "dd-MM-yyyy", CultureInfo.CurrentCulture);
            final = final.AddDays(1000);
            Console.WriteLine(final.ToString("dd-MM-yyyy"));
        }
    }
}
