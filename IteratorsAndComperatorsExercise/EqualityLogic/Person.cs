using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
   public class Person:IComparable
    {
        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
                
        }


        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            Person abb = obj as Person;
            int result= this.Name.CompareTo(abb.Name);
            if (result==0)
            {
                result = this.Age.CompareTo(abb.Age);


            }
            return result;
        }

        public override bool Equals(object obj)
        {
           
            //if (obj is Person other)
            //{

            //}
            Person abb = obj as Person;
           
                
                
         return this.Name==abb.Name&&this.Age==abb.Age;

                

            
           
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age);
        }

    }
}
