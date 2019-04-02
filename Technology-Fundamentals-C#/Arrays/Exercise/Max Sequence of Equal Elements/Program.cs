using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int highestSequence = 1;
            int sequence = 1;
            int currentSequenceNumber = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    sequence++;
                }

                if (sequence > highestSequence)
                {
                    currentSequenceNumber = arr[i];
                    highestSequence = sequence;
                }

                if (arr[i] != arr[i + 1])
                {
                    sequence = 1;
                }

            }
            for (int i = 0; i < highestSequence; i++)
            {
                Console.Write(currentSequenceNumber+" ");
            }
        }
    }
}
