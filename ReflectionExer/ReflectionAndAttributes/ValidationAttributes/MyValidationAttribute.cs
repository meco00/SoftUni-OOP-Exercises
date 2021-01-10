using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
   public abstract class MyValidationAttribute:Attribute
    {
        public abstract bool isValid(object obj); 
    }
}
