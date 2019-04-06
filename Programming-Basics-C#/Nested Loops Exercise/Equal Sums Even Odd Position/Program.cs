using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {

            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int counter = number1;
            int counter1 = 0;
            string number1String = number1.ToString();
            string number2String = number2.ToString();            

            while (counter <= number2)
            {
                counter1 = counter;
                int evenSum = 0;
                int oddSum = 0;
                for (int i = 1; i <= number1String.Length; i++)
                {                    
                    int lastNumber = counter1 % 10;
                    counter1 /= 10;
                    if (i % 2 == 0) evenSum += lastNumber;
                    else oddSum+= lastNumber;
                }
                if (evenSum == oddSum) Console.Write(counter+ " ");
                
                counter++;
            }
        }
    }
}
