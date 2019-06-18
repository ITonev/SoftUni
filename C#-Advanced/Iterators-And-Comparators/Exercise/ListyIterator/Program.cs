using System;

namespace ListyIterator
{
    public class Program
    {
        public static string[] tokens;
        public static ListyIterator<string> listy;

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    if (command.StartsWith("Create"))
                    {
                        tokens = command.Substring(6).Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        listy = new ListyIterator<string>(tokens);
                    }

                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;

                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;

                        case "Print":
                            listy.Print();
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }
        }
    }
}
