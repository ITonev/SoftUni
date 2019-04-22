using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            string book2 = string.Empty;

            while (counter < number && ((book2=Console.ReadLine()) != book))
            {                
                counter++;
            }
            
            //оператор ?: при равни стойности - първия текст, при различни, текста след ":"
            //Console.WriteLine(book == book2 ?
            //$"You checked {counter} books and found it." :
            //$"The book you search is not here!\nYou checked {counter} books.");
            if (counter >= number)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
            else Console.WriteLine($"You checked {counter} books and found it.");
            

        }
    }
}
