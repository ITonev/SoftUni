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
            double sum = 0;
            double counter = 1;
            double counter2 = 0;
            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum += grade;
                    counter++;
                }
                if (grade < 4.00) counter2++;
                if (counter2 == 2) break; 
            }
            if (counter2==2) Console.WriteLine($"{student} has been excluded at {counter} grade");
            else Console.WriteLine($"{student} graduated. Average grade: {(sum/12):F2}");

        }
    }
}
