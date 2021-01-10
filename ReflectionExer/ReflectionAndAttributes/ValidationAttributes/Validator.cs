using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool isValid(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            PropertyInfo[] properties = obj.GetType().GetProperties();



            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> propertyAttribute = property
                    .GetCustomAttributes()
                    .Where(x=>x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();
                foreach (MyValidationAttribute attribute in propertyAttribute)
                {
                    bool result =attribute.isValid(property.GetValue(obj));
                    if (!(result))
                    {
                        return false;

                    }
                }
            }



            return true;

        }
    }
}
