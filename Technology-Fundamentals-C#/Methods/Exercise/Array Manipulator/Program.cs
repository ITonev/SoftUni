using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                var tokens = command
                    .Split();

                if (command.Contains("exchange"))
                {
                    int splitIndex = int.Parse(tokens[1]);
                    if (splitIndex > array.Length - 1 || splitIndex < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        PrintExchangedArray(array, splitIndex);
                    }
                }

                else if (command.Contains("max"))
                {
                    string type = tokens[1];
                    MaxEvenOrOddNumber(array, type);
                }

                else if (command.Contains("min"))
                {
                    string type = tokens[1];
                    MinEvenOrOddNumber(array, type);
                }

                else if (command.Contains("first"))
                {
                    int count = int.Parse(tokens[1]);
                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        string type = tokens[2];
                        PrintFirstCountNumber(array, count, type);
                    }
                }

                else if (command.Contains("last"))
                {
                    int count = int.Parse(tokens[1]);
                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        string type = tokens[2];
                        PrintLasttCountNumber(array, count, type);
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        private static void PrintLasttCountNumber(int[] array, int count, string type)
        {
            int currentCount = count;
            var resultList = new List<int>();

            if (type == "even")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0)
                    {
                        resultList.Add(array[i]);
                        currentCount--;
                    }
                    if (currentCount == 0)
                    {
                        break;
                    }

                }
            }

            else if (type == "odd")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0)
                    {
                        resultList.Add(array[i]);
                        currentCount--;
                    }
                    if (currentCount == 0)
                    {
                        break;
                    }
                }
            }

            if (currentCount == count)
            {
                Console.WriteLine($"[{string.Join("", resultList)}]");
            }
            else
            {
                resultList.Reverse();
                Console.WriteLine($"[{string.Join(", ", resultList)}]");
            }
        }

        private static void PrintFirstCountNumber(int[] array, int count, string type)
        {
            int currentCount = count;
            var resultList = new List<int>();
            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        resultList.Add(array[i]);
                        currentCount--;
                    }
                    if (currentCount == 0)
                    {
                        break;
                    }
                }
            }

            else if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        resultList.Add(array[i]);
                        currentCount--;
                    }
                    if (currentCount == 0)
                    {
                        break;
                    }
                }
            }

            if (currentCount == count)
            {
                Console.WriteLine($"[{string.Join("", resultList)}]");
            }
            else
            {
                Console.WriteLine($"[{string.Join(", ", resultList)}]");
            }
        }

        private static void MinEvenOrOddNumber(int[] array, string type)
        {
            int minNum = int.MaxValue;
            int minIndex = -1;
            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= minNum)
                    {
                        minNum = array[i];
                        minIndex = i;
                    }
                }
            }

            else if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] <= minNum)
                    {
                        minNum = array[i];
                        minIndex = i;
                    }
                }
            }

            if (minNum == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        private static void MaxEvenOrOddNumber(int[] array, string type)
        {
            int maxNum = -1;
            int maxIndex = -1;
            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= maxNum)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                    }
                }
            }

            else if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] >= maxNum)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                    }
                }
            }

            if (maxNum == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        private static void PrintExchangedArray(int[] array, int splitIndex)
        {
            for (int i = 0; i < splitIndex + 1; i++)
            {
                int firstNum = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = firstNum;
            }
        }
    }
}
