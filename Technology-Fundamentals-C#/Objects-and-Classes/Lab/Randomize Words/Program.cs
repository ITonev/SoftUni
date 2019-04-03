using System;
using System.Linq;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split();
            
            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomNum = random.Next(0, words.Length);
                string currentWord = words[i];
                words[i] = words[randomNum];
                words[randomNum] = currentWord;
            }
                Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
