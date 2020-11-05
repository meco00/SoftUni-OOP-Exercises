using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering
{
    interface IGameObject
    {
        void Draw(IDrawer drawer);
    }
}
