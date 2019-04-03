using System;

namespace Replace_Repeating_Chars
{
    class Program
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();

            for (int i = 0; i < text.Length - 1; i++)
            {
                while (text[i] == text[i + 1])
                {
                    text = text.Remove(i + 1, 1);

                    if (i==text.Length-1)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
