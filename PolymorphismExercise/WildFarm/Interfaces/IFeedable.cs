using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces
{
   public interface IFeedable
    {
        void Feed(IFood food);

        int FoodEaten { get; }

        ICollection<Type> PrefferedFoodTypes { get; }
    }
}
