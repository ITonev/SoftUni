using System;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split();
            var firstString = text[0];
            var secondString = text[1];

            var sum = SumOfTwoStrings(firstString, secondString);
            Console.WriteLine(sum);
        }

        private static object SumOfTwoStrings(string firstString, string secondString)
        {
            var shortestString = Math.Min(firstString.Length, secondString.Length);
            var sum = 0;

            for (int i = 0; i < shortestString; i++)
            {
                sum += (firstString[i] * secondString[i]);
            }

            if (firstString.Length>secondString.Length)
            {
                for (int i = secondString.Length; i < firstString.Length; i++)
                {
                    sum += firstString[i];
                }
            }

            else if (firstString.Length < secondString.Length)
            {
                for (int i = firstString.Length; i < secondString.Length; i++)
                {
                    sum += secondString[i];
                }
            }

            return sum;
        }
    }
}
