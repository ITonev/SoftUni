using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectiontype = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            
            switch (projectiontype)
            {
                case "Premiere": Console.WriteLine($"{((row*column)*12.00):F2}");break;
                case "Normal": Console.WriteLine($"{((row * column) * 7.50):F2}"); break;
                case "Discount": Console.WriteLine($"{((row * column) * 5.00):F2}"); break;
                default:
                    break;
            }
        }
    }
}
