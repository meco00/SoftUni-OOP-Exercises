using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
        {
            return obj != null;
        }
    }
}
