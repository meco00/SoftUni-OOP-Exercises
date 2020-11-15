using System;
using System.Collections;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {

            ICollection<IShape> collection = new List<IShape>();

            collection.Add(new Rectangle());
            collection.Add(new Circle());
            collection.Add(new Square());

            foreach (var item in collection)
            {
                Console.WriteLine(item.Draw());
            }

        }
    }
}
