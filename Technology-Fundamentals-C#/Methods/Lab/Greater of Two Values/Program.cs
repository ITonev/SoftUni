using System;

namespace Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = 7;
            double secondNum = 3;
            var result = Math.Round((firstNum / secondNum), 32);
            Console.WriteLine(result);
        }
    }  
}