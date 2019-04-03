using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            var text = Console.ReadLine();

            while (text.Contains(word))
            {
                var index = text.IndexOf(word);
                text = text.Remove(index, word.Length);
            }

            Console.WriteLine(text);
        }
    }
}
