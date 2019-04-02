using System;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello stupid World");
            Console.SetCursorPosition(3, 5);
            MyShot();
        }

        static void MyShot()
        {
            Console.WriteLine("Sup");
        }
    }
}
