using System;
using System.Linq;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = name => Console.WriteLine(name);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(action);
        }
    }
}
