using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }


        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        public int CurrentIndex { get; private set; }

        public LibraryIterator(List<Book> books)
        {
            this.CurrentIndex = -1;
            this.books = books;
        }

        public Book Current => this.books[CurrentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++CurrentIndex < this.books.Count;
        }

        public void Reset()
        {

        }
    }
}
