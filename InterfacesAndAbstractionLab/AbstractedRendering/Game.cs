using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AbstractedRendering
{
    class Game
    {
        private List<IGameObject> objects;
        private IDrawer drawer;


        public Game(IDrawer drawer)
        {
            this.drawer = drawer;
            objects = new List<IGameObject>();
            objects.Add(new Snake());
            objects.Add(new Food());
            objects.Add(new Obstacle());
            objects.Add(new Food());
            objects.Add(new Snake());
            objects.Add(new Obstacle());


        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000);
                foreach (IGameObject item in objects)
                {

                    item.Draw(this.drawer);

                }

            }
        }


    }
}
