using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                encrypted.Append((char)(text[i] + 3));
            }
            Console.WriteLine(encrypted.ToString());
        }
    }
}
