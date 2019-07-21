using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            var result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }