using PizzaCalories.Common;

namespace PizzaCalories
{
    public class BakingTechnique
    {
        //        •	Crispy - 0.9;
        //•	Chewy - 1.1;
        //•	Homemade - 1.0;

        private const double crispy = 0.9;
        private const double chewy =1.1;
        private const double homemade = 1.0;

       

        public static double Crispy => crispy;
        public static double Chewy => chewy;
        public static double Homemade => homemade;


        public static double ValidateTechniques(string techType)
        {
            techType = techType.ToLower();
            switch (techType)
            {
                case "crispy":
                    return Crispy;
                    
                case "chewy":
                    return Chewy;
                    
                case "homemade":
                    return Homemade;
                    
                default:
                    throw new System.Exception(CommonGeneral.INVALID_DOUGH_TYPE);

            }
        }

    }
}