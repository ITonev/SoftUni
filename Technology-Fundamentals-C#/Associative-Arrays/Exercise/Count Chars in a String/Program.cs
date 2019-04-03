using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = Console.ReadLine().Where(x=>x!=' ').ToArray();

            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dic.ContainsKey(text[i]))
                {
                    dic[text[i]]=0;
                }
                dic[text[i]]++;
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
