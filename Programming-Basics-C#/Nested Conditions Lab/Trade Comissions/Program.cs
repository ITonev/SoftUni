using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double comission = -1;

            if (city == "Sofia")
            {
                if (sales >= 0 && sales <= 500) comission = 0.05;
                else if (sales > 500 && sales <= 1000) comission = 0.07;
                else if (sales > 1000 && sales <= 10000) comission = 0.08;
                else if (sales > 10000) comission = 0.12;
              
            }
            else if (city == "Varna")
            {
                if (sales >= 0 && sales <= 500) comission = 0.045;
                else if (sales > 500 && sales <= 1000) comission = 0.075;
                else if (sales > 1000 && sales <= 10000) comission = 0.10;
                else if (sales > 10000) comission = 0.13;
            }
            else if (city == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500) comission = 0.055;
                else if (sales > 500 && sales <= 1000) comission = 0.08;
                else if (sales > 1000 && sales <= 10000) comission = 0.12;
                else if (sales > 10000) comission = 0.145;
            }
            Console.WriteLine($"{sales*comission:F2}");
            if (comission== -1)
            {
                Console.WriteLine("error");
            }
        }
    }
}
