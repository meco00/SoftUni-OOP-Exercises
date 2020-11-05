using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace IteratorsAndComparators
{
   public class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
            
            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }

            IComparer<Book> comparer = new BookComparator();
            //int min = 0;
            //for (int i = 0; i < libraryTwo.Books.Count; i++)
            //{
            //    for (int j = 0; j < libraryTwo.Books.Count; j++)
            //    {
            //        if (comparer.Compare(libraryTwo.Books[min], libraryTwo.Books[min])>0)
            //        {
            //            min = j;
            //        }


            //    }
            //    var temp = libraryTwo.Books[min];
            //    libraryTwo.Books[min] = libraryTwo.Books[i];
            //    libraryTwo.Books[i] = temp;

            //}

            //Console.WriteLine(libraryTwo.Books[min]);
        }
    }
}
