using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get;  }

        public override string ToString()
        {
            //Console.WriteLine(manager.Name);
            //Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));
            return sb.ToString().Trim();
        }
    }
}
