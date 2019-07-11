using System;

namespace Car
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
