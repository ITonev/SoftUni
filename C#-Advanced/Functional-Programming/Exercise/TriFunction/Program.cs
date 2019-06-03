using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, int, bool> isValidWord = (x, num) => x.ToCharArray()
                .Select(ch => (int)ch).Sum() >= num;

            Func<string[], int, Func<string, int, bool>, string> validName = (arr, num, func) => arr
                .FirstOrDefault(x => func(x, num));

            var result = validName(names, number, isValidWord);

            Console.WriteLine(result);
        }
    }
}
