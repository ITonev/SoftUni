using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> elements;

        private int index;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index + 1 < this.elements.Count)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine($"{this.elements[this.index]}");

            }

            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Operation!");
               // throw new ArgumentOutOfRangeException("Invalid Operation!");
            }
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.elements.Count)
            {
                return true;
            }

            return false;
        }


    }
}
