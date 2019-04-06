using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stupid_Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());

            for (int first = 1; first <= n; first++)
            {
                for (int second = 1; second <= n; second++)
                {
                    for (char third = 'a'; third <'a'+ L; third++)
                    {
                        for (char fourth = 'a'; fourth <'a' + L; fourth++)
                        {
                            for (int fifth = Math.Max(first,second)+1; fifth <=n; fifth++)
                            {
                                Console.Write($"{first}{second}{third}{fourth}{fifth} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
