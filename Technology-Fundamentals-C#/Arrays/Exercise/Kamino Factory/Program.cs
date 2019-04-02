using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            int[] longestDNA = new int[lenght];

            int longestDNASequenceIndex = -1;
            int longestDNASum = -1;
            int longestDNASubsequenceOfOnes = -1;
            int longestDNAStartingIndex = -1;

            int currentDNASequenceIndex = 0;
            int currentDNASum = 0;
            int currentSubsequenceOfOnes = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Clone them!")
                {
                    break;
                }

                int[] currentDNASample = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                currentDNASequenceIndex++;
                int currentStartingIndex = -1;
                int count = 0;

                for (int i = 0; i < lenght; i++)
                {
                    if (currentDNASample[i] == 1)
                    {
                        currentDNASum++;
                        count++;

                        if (count >= currentSubsequenceOfOnes)
                        {
                            currentSubsequenceOfOnes = count;
                            currentStartingIndex = i - count;
                        }
                    }

                    else
                    {

                        count = 0;
                    }
                }

                if (currentSubsequenceOfOnes > longestDNASubsequenceOfOnes)
                {
                    longestDNA = currentDNASample;
                    longestDNASum = currentDNASum;
                    longestDNASubsequenceOfOnes = currentSubsequenceOfOnes;
                    longestDNASequenceIndex = currentDNASequenceIndex;
                    longestDNAStartingIndex = currentStartingIndex;
                }

                else if (currentSubsequenceOfOnes == longestDNASubsequenceOfOnes
                        && currentStartingIndex < longestDNAStartingIndex)
                {
                    longestDNA = currentDNASample;
                    longestDNASum = currentDNASum;
                    longestDNASubsequenceOfOnes = currentSubsequenceOfOnes;
                    longestDNASequenceIndex = currentDNASequenceIndex;
                }

                else if (currentSubsequenceOfOnes == longestDNASubsequenceOfOnes
                        && currentStartingIndex == longestDNAStartingIndex
                        && currentDNASum > longestDNASum)
                {
                    longestDNA = currentDNASample;
                    longestDNASum = currentDNASum;
                    longestDNASubsequenceOfOnes = currentSubsequenceOfOnes;
                    longestDNASequenceIndex = currentDNASequenceIndex;
                }
                currentDNASum = 0;
            }

            Console.WriteLine($"Best DNA sample {longestDNASequenceIndex} with sum: {longestDNASum}.");
            Console.WriteLine(string.Join(" ", longestDNA));
        }
    }
}
