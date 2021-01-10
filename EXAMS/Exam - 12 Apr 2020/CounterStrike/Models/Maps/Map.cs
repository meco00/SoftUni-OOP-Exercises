using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {

        public string Start(ICollection<IPlayer> players)
        {
            
            List<IPlayer> terorists = players.Where(x => x.GetType().Name == "Terrorist").ToList();
            List<IPlayer> counterTerorists = players.Where(x => x.GetType().Name == "CounterTerrorist").ToList();

            while (terorists.Any(x=>x.Health>0)&&counterTerorists.Any(x=>x.Health>0))
            {
                foreach (IPlayer terorist in terorists)
                {
                    foreach (IPlayer counterTerorist in counterTerorists)
                    {
                        counterTerorist.TakeDamage(terorist.Gun.Fire());

                    }

                }


                foreach (IPlayer counterTerorist in counterTerorists)
                {
                    foreach (IPlayer terorist in terorists)
                    {
                        terorist.TakeDamage(counterTerorist.Gun.Fire());

                    }

                }


            }


            if (!(terorists.Any(x => x.Health > 0)))
            {
                return "Counter Terrorist wins!";

            }

            return "Terrorist wins!";



        }
    }
}
