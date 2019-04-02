using System;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine()
                .Split();

            string[] arr2 = Console.ReadLine()
                .Split();

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr1[j]==arr2[i])
                    {
                        Console.Write(arr2[i]+" ");
                    }
                }
            }
        }
    }
}
