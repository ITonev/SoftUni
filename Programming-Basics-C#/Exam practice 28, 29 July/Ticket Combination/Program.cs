using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 66; i <= 76; i += 2) 
            {
                for (char j = 'f'; j >= 'a'; j--) 
                {
                    for (char m = 'A'; m <='C'; m++)
                    {
                        for (int n = 1; n <= 10; n++)
                        {
                            for (int p = 10; p >= 1; p--)
                            {
                                counter++;
                                if (counter==number)
                                {
                                    int moneyPrice = i + j + m + n + p;
                                    Console.WriteLine($"Ticket combination: {(char)(i)}{j}{m}{n}{p} \n" +
                                        $"Prize: {moneyPrice} lv.");
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            
        }
    }
}
