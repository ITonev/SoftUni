using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int counter = number1;

            while (counter<=number2)
            {
                int counter1 = counter;
                int rightSum = 0;
                int leftSum = 0;
                int midNum = 0;

                for (int i = 1; i <= 5; i++)
                {
                    int lastNum = counter1 % 10;
                    counter1 /= 10;
                    if (i == 1 || i == 2) rightSum += lastNum;
                    else if (i == 4 || i == 5) leftSum += lastNum;
                    else if (i == 3) midNum = lastNum;
                }

                if (rightSum == leftSum) Console.Write(counter+ " ");

                else
                {
                    int min = Math.Min(leftSum, rightSum) + midNum;
                    int max = Math.Max(leftSum, rightSum);

                    if (min == max) Console.Write(counter+ " ");
                }               
                
                counter++;
            }
        }
    }
}
