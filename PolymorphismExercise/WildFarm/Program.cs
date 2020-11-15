using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WildFarm.Contracts;
using WildFarm.Contracts.Core;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
