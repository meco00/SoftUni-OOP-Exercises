using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                   string output= commandInterpreter.Read(Console.ReadLine());
                    Console.WriteLine(output);
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }

            }
           

           
        }
    }
}
