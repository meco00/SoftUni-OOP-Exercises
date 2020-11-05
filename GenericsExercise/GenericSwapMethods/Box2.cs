using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethods
{
   public class Box2<T>
    {
        public List<T> GenericList { get; set; } = new List<T>();

        public void Add(T element)
        {
            this.GenericList.Add(element);
        }

        public static List<T> SwapElements(List<T> list,int firstIndex,int secondIndex)
        {
            
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;

            return list;


        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in GenericList)
            {
                sb.AppendLine($"{item.GetType()}: {item}");

            }


            return sb.ToString().TrimEnd();
        }


    }
}
