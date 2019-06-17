using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> elements;

        private int index;

        public ListyIterator()
        {
            this.elements = new List<T>();
            this.index = 0;
        }
    }
}
