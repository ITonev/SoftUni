using System;
using System.Text;

namespace Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(BuildString(text, n));
        }

        private static string BuildString(string text, int n)
        {
            StringBuilder repeatedString = new StringBuilder();
            string news = string.Empty;

            for (int i = 0; i < n; i++)
            {
                repeatedString.Append(text);
            }

            return repeatedString.ToString();
        }
    }
}
