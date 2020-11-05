using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractedRendering.Drawers
{
    class FileDrawer : IDrawer
    {
        private string path;
        public FileDrawer(string pat)
        {
            this.path = pat;

        }
        public void Write(string input)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(input);

            }
        }

        public void WriteLine(string input)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(input);

            }
           
        }
    }
}
