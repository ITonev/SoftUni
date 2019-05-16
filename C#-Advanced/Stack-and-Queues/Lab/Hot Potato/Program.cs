using System;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            Queue<string> kids = new Queue<string>(input);

            var num = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < num; i++)
                {
                    var currentKid = kids.Dequeue();
                    kids.Enqueue(currentKid);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
