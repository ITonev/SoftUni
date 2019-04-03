using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var text = Console.ReadLine();
            var result = Regex.Matches(text, @"\b[A-Z][a-z]+[\s{1}][A-Z][a-z]+\b");

            foreach (var match in result)
            {
                Console.Write(match+" ");
            }
        }
    }
}
