using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            double sum = 0;
            double counter = 1;

            while (counter<=12)
            {
                if (grade>=4.00)
                {
                    sum += grade;
                    counter++;
                }
               if (counter<=12) grade = double.Parse(Console.ReadLine());
            }
            double average = sum / 12;
            
            Console.WriteLine($"{student} graduated. Average grade: {average:F2}"); 

        }
    }
}
