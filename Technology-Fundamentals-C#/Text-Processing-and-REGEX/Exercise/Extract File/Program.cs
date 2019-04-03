using System;

namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Console.ReadLine().Split("\\");
            var fileName = filePath[filePath.Length - 1].Split(".");
            Console.WriteLine($"File name: {fileName[0]}");
            Console.WriteLine($"File extension: {fileName[1]}");
        }
    }
}
