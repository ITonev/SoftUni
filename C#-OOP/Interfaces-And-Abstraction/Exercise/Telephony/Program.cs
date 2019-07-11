using System;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();

            foreach (var number in numbers)
            {
                try
                {
                    Smartphone smartphone = new Smartphone() { Number = number };

                    Console.WriteLine(smartphone.Call());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var website in websites)
            {
                try
                {
                    Smartphone smartphone = new Smartphone() { Website = website };

                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
