using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rand = new RandomList();

            rand.AddRange(new[] { "Peshi", "Mishi", "Goshi" });

            Console.WriteLine(rand.RandomString());
        }
    }
}
