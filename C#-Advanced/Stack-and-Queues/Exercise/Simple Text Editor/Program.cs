using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> texts = new Stack<string>();

            StringBuilder sb = new StringBuilder();

            texts.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                
                if (command == "1") // 1 someString - appends someString to the end of the text
                {
                    var textToAdd = input[1];

                    sb.Append(textToAdd);

                    texts.Push(sb.ToString());
                }

                else if (command == "2") // 2 count - erases the last count elements from the text
                {
                    var count = int.Parse(input[1]);

                    if (count >= sb.Length)
                    {
                        sb.Clear();
                        texts.Push(sb.ToString());
                        continue;
                    }

                    sb.Remove(sb.Length - count, count);

                    texts.Push(sb.ToString());
                }

                else if (command == "3") // 3 index - returns the element at position index from the text
                {
                    var index = int.Parse(input[1]);

                    if (index >= 0 && index <= sb.Length)
                    {
                        Console.WriteLine(sb[index - 1]);
                    }
                }

                else if (command == "4") // 4 undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
                {
                    var undo = texts.Pop();
                    var last = texts.Peek();
                    sb.Clear();
                    sb.Append(last);
                }
            }
        }
    }
}
