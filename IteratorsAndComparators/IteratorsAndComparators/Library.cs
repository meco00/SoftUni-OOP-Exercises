using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books.ToList());
        }


        public List<Book> Books { get; set; }


        // Books.Sort();
        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.Books.ToList());




        IEnumerator IEnumerable.GetEnumerator()
        {
            Books.Sort(new BookComparator());
            return this.GetEnumerator();
        }



        private class LibraryIterator : IEnumerator<Book>
        {

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            private List<Book> books;
            private int currentIndex = -1;

            public Book Current => books[currentIndex];

            object IEnumerator.Current => this.books[currentIndex];

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }



    }
}
