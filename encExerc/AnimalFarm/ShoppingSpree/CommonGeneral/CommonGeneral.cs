using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class CommonGeneral
    {
        public static string IsNullOrEmpty = "Name cannot be empty";
        public static string IsNegativeNum = "Money cannot be negative";


        public static void  ValidateName(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new Exception(IsNullOrEmpty);

            }

        }    

        public static void ValidateMoney(double value)
        {
            if (value<0)
            {
                throw new Exception(IsNegativeNum);

            }
        }


    }
}
