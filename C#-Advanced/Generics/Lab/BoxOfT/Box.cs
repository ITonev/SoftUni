using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> arr;

        public Box()
        {
            this.arr = new List<T>();
        }

        public int Count => arr.Count;

        public void Add(T element)
        {
            this.arr.Add(element);
        }

        public T Remove()
        {
            if (Count > 0)
            {
                var topElement = arr.Last();
                this.arr.RemoveAt(Count-1);

                return topElement;
            }

            throw new ArgumentOutOfRangeException("List is empty");
        }
    }
}
