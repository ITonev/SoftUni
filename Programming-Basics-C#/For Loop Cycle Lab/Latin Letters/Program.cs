using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 97; i <= 122; i++)
            {
                char c = (char)(i);
                // или i = Convert.ToChar(i);
                Console.WriteLine(c);               
            }
        }
    }
}
