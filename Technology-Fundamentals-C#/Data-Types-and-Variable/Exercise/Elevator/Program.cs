using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            var result = (int)Math.Ceiling(numberOfPeople / (double)capacity);

            Console.WriteLine(result);
        }
    }
}
