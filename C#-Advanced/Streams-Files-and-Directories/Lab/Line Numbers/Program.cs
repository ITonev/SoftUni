using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("Resources/02. Line Numbers/Input.txt"))
            {
                var counter = 0;

                using (var writer = new StreamWriter("Resources/02. Line Numbers/Output.txt", true))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        line = $"{++counter}. {line}";

                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
