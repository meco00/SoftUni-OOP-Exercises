using PizzaCalories.Common;

namespace PizzaCalories
{
    public class FlourType
    {

        //        •	White - 1.5;
        //•	Wholegrain - 1.0;

        private const double White = 1.5;
        private const double Wholegrain = 1.0;


        public static double GetWhite =>  White;
        public static double GetWholegrain  =>  Wholegrain;
            

        public static double ValidateType(string value)
        {
            value = value.ToLower();
            switch (value)
            {
                case"white":
                    return GetWhite;
                    
                case "wholegrain":
                    return GetWholegrain;
                default:
                    throw new System.Exception(CommonGeneral.INVALID_DOUGH_TYPE);
                    
                  
            }
        }


        




    }
}