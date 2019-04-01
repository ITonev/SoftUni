using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            var reversed = text.ToCharArray();
            Array.Reverse(reversed);
            var reversedText = new string(reversed); 
            Console.WriteLine(reversedText);
        }
    }
}
