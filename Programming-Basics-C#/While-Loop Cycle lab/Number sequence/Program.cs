using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            int min = int.MaxValue;

            while (true)
            {
                string imput = Console.ReadLine();
                if (imput == "END") break;
                int num = int.Parse(imput);
                if (num > max) max = num; 
                if (num < min) min = num;
            }
            Console.WriteLine("Max number: "+max);
            Console.WriteLine("Min number: "+min);

        }
    }
}
