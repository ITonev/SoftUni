using System;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var parentheses = input.ToCharArray();
            var firstHalf = parentheses.Length / 2;

            var isBalanced = true;

            var firstSymbols = new char[] { '(', ')' };
            var secondSymbols = new char[] { '{', '}' };
            var thirdSymbols = new char[] { '[', ']' };

            for (int i = 0; i < firstHalf; i++)
            {
                var currentChar = parentheses[i];

                for (int j = parentheses.Length - 1-i; j >= firstHalf; j--)
                {
                    var oppositeChar = parentheses[j];

                    if ((firstSymbols.Contains(currentChar) && firstSymbols.Contains(oppositeChar))
                        || (secondSymbols.Contains(currentChar) && secondSymbols.Contains(oppositeChar))
                        || (thirdSymbols.Contains(currentChar) && thirdSymbols.Contains(oppositeChar)))
                    {
                        isBalanced = true;
                        break;
                    }

                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }

                if (isBalanced==false)
                {
                    break;
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
