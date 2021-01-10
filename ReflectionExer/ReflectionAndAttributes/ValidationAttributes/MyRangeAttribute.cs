using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int min,int max)
        {
            this.minValue = min;
            this.maxValue = max;

        }

        public int minValue { get; set; }
        public int maxValue { get; set; }

        public override bool isValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();

            }
            int number = (int)obj;

            if (number<minValue||number>maxValue)
            {
                return false;

            }
            return true;
        }
    }
}
