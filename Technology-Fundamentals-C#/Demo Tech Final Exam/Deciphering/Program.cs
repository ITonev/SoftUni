using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedString = Console.ReadLine();
            var substrings = Console.ReadLine().Split();

            var pattern = @"^[d-z{}|#]*$";
            
            if (Regex.IsMatch(encryptedString, pattern))
            {
                var decryptedString = encryptedString.Select(x => x = (char)(x - 3));

                var result = string.Empty;

                foreach (var @char in decryptedString)
                {
                    result += @char;
                }

                result = result.Replace(substrings[0], substrings[1]);
                Console.WriteLine(result);
            }

            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
