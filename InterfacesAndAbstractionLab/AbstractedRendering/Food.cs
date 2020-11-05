using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering
{
    class Food : IGameObject

    {
        

        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("az sum hranata");
        }
    }
}
