using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<int>();
            box.Add(2);
            box.Add(4);
            box.Add(6);
            box.Add(8);

            Console.WriteLine(box.Remove());
        }
    }
}
