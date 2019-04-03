using System;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string command = Console.ReadLine();
                if (command=="end")
                {
                    break;
                }

                var reversed = command.Reverse().ToArray();
                var revs = new string(reversed);
                Console.WriteLine($"{command} = {revs}");
            }

        }
    }
}
