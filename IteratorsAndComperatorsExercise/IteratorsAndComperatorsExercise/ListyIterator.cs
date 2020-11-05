using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComperatorsExercise
{
   public class ListyIterator<T>: IEnumerable<T>
    {

        private List<T> list;
        private int index=0;

        public ListyIterator(params T[] list)
        {
            this.list = list.ToList();
        }


        public bool Move()
        {
            if (index+1>=list.Count)
            {
                return false;

            }

            index++;
            return true;

        }
        public bool HasNext()
        {
            if (index + 1 >= list.Count)
            {
                return false;

            }

           
            return true;

        }
        public void Print()
        {
            if (index>=list.Count||list.Count==0)
            {
                throw new Exception("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }

        }
        public void PrintAll()
        {

            Console.WriteLine(String.Join(" ",list));

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return (list[i]);


            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
