using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command=="3:1")
                {
                    break;
                }

                var tokens = command.Split();

                if (tokens[0] == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex < 0 || startIndex >= code.Count)
                    {
                        startIndex = 0;
                    }
                    if (endIndex < 0 || endIndex >= code.Count)
                    {
                        endIndex = code.Count - 1;
                    }

                    string concat = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concat += code[i];
                    }

                    code.RemoveRange(startIndex, endIndex - startIndex + 1);
                    code.Insert(startIndex, concat);
                }

                else if (tokens[0] == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);

                    string textToDivide = code[index];

                    int part = textToDivide.Length / partitions;
                    int lastPart = part + textToDivide.Length % partitions;

                    var partitionedText = new List<string>();
                    
                    for (int i = 0; i < partitions; i++)
                    {
                        string currentWord = textToDivide.Substring(i * part, part);

                        if (i == partitions - 1)
                        {
                            currentWord = textToDivide.Substring(i * part, lastPart);
                        }

                        partitionedText.Add(currentWord);
                    }

                    code.RemoveAt(index);
                    code.InsertRange(index, partitionedText);
                }
            }

            Console.WriteLine(string.Join(" ", code));
        }
    }
}
