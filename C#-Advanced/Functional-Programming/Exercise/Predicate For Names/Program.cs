using System;
using System.Linq;

namespace Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split();

            Func<string, bool> func = n => n.Length <= lenght;

            names = names.Where(x => func(x)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
