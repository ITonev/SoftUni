using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i < arr.Length; i++)
            {
                bool isItTop = true;
                for (int k = i; k < arr.Length - 1; k++)
                {
                    if (arr[i] <= arr[k + 1])
                    {
                        isItTop = false;
                        break;
                    }
                }

                if (isItTop)
                {
                    Console.Write(arr[i]+" ");
                }
            }
        }
    }
}
