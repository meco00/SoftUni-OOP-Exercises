using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering.Contracts
{
    interface IDrawer
    {
        void Write(string input);

        void WriteLine(string input);
    }
}
