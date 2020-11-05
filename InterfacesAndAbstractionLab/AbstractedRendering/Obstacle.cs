using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering
{
    class Obstacle : IGameObject
    {
        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("na putq");
        }
    }
}
