using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CommandPattern.Core.Models
{
   public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            
            
            
                var token = args.Split().ToArray();

                string result = string.Empty;

                string getType = $"{token[0]}Command";

                Type type = Assembly.GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name.ToLower() == getType.ToLower());


                if (type == null)
                {
                    throw new ArgumentException("Wrong TYPE input");

                }

                ICommand currentComand = (ICommand)Activator.CreateInstance(type);
                

               result= currentComand.Execute(token.Skip(1).ToArray());


            return result;
                
            
            

        }
    }
}
