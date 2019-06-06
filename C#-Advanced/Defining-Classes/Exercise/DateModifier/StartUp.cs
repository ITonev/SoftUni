using System;

namespace DateModifier
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            DateModifier date = new DateModifier();
                        
            Console.WriteLine(date.DifferenceInDays(firstDate, secondDate));


        }
    }
}
