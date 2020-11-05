using AbstractedRendering.Contracts;
using AbstractedRendering.Drawers;
using System;

namespace AbstractedRendering
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawer drawer = new HtmlDrawer("../../../game.html");
            Game game = new Game(drawer);
            game.Start();
        }
    }
}
