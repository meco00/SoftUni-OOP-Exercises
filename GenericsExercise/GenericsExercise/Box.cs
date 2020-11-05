using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Box<T> where T:IComparable<T>
    {
        public T Value { get; set; }

        // public List<T> List { get; set; }

        public Box(T element)
        {
            this.Value = element;

        }

        public static int CountOfComparers(List<Box<T>> list, T element)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.Value.CompareTo(element)>0)
                {
                    count++;

                }

            }

            return count;
        }

        //public override string ToString()
        //{
        //    return $"{Value.GetType()}: {this.Value}";
        //}

    }
}
