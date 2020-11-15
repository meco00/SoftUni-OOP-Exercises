using Raiding.Contracts.Core;
using Raiding.Contracts.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Contracts
{
   public class Engine : IEngine
    {
        private readonly ICollection<BaseHero> heroes;

        private readonly HeroFactory heroFactory;

        public Engine()
        {
            heroes = new List<BaseHero>();
            heroFactory = new HeroFactory();
        }


        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            BaseHero hero = null;
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    hero = heroFactory.Create(type, name);
                    heroes.Add(hero);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    i--;
                }





            }

            int bossPower = int.Parse(Console.ReadLine());

            PrintAbility();

            Console.WriteLine(BossFight(bossPower));

        }

        private string BossFight(int bossPower)
        {
            if (heroes.Sum(x => x.Power) >= bossPower)
            {
               return"Victory!";

            }
            else
            {
                return "Defeat...";
            }
        }

        private void PrintAbility()
        {
            foreach (BaseHero item in heroes)
            {
                Console.WriteLine(item.CastAbility());

            }
        }
    }
}
