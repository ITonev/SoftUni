using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericCount
{
    public class Box<T>
        where T : IComparable<T>
    {
        private List<T> boxList;

        public Box()
        {
            this.boxList = new List<T>();
        }

        public void Add(T element)
        {
            this.boxList.Add(element);
        }

        public int CompareTo(T element)
        {
            int counter = 0;

            foreach (var box in this.boxList)
            {

                if (box.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.boxList)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
