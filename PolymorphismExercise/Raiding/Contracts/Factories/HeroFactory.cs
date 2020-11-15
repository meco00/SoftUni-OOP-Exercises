using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Raiding.Contracts.Factories
{
    public class HeroFactory
    {

        public BaseHero Create(string strType,string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name == strType);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid hero!");

            }

            object[] ctorParams = new object[] { name };



            BaseHero hero = (BaseHero)Activator.CreateInstance(type, ctorParams);

            return hero;


        }


    }
}
