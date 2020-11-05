using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Dough
    {
        private const int MIN_RANGE = 1;
        private const int MAX_RANGE = 200;
        
        private int weight;
        private double calories;

        public Dough(string type ,string tech,int grams)
        {
            
            this.Weight = grams;
            calories = this.CalculateDough(type, tech);
            

        }



        public double Calories => this.calories;

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception(String.Format(CommonGeneral.INVALID_DOUGH_RANGE,MIN_RANGE,MAX_RANGE));
                }
                else
                {
                    this.weight = value;
                }



            }
        }



        private double CalculateDough(string flourType,string techType)
        {
            double flour = FlourType.ValidateType(flourType);

            double technique = BakingTechnique.ValidateTechniques(techType);


            double sum = (2 * weight * flour * technique);

            return sum;


        }





        


    }
}
