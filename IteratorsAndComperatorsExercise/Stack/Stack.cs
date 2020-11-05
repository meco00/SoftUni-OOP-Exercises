using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
  public  class Stack<T> : IEnumerable<T>
    {

        private List<T> list;
        private int index = 0;

        public Stack(params T[] list)
        {
            this.list = list.ToList();


        }

        public void Push(params T[] toAdd)
        {
            list.AddRange(toAdd.ToList());

        }

        public void Pop()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No elements");

            }
            else
            {
                list.Remove(list[list.Count - 1]);
            }
            
           
        }














        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count-1; i >= 0; i--)
            {
                yield return list[i];


            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];


            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
