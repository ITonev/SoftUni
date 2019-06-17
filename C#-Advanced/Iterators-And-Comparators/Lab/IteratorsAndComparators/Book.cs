using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }

        public int CompareTo(Book other)
        {
            if (this.Year != other.Year)
            {
                return this.Year - other.Year;
            }

            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }
    }
}
