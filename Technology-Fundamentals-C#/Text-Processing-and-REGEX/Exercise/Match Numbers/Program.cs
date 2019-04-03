using System;
using System.Text.RegularExpressions;

namespace Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex(@"(^|(?<=\s))-?[\d.]+($|(?=\s))");
            var result = regex.Matches(input);
            foreach (var match in result)
            {
                Console.Write(match+" ");
            }

        }
    }
}
