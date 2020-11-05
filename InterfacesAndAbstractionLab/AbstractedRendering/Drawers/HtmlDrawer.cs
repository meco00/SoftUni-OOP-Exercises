using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractedRendering.Drawers
{
   public class HtmlDrawer : IDrawer
    {
        private string path;

        private StringBuilder result;

        public HtmlDrawer(string path)
        {
            this.path = path;
            result = new StringBuilder();

        }


        public void Write(string input)
        {
            result.Append(input);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write($"<html><head><body><h1>Best Game!!!</h1><p>{result.ToString()}</p></body></head></html>");

            }
        }

        public void WriteLine(string input)
        {
            result.Append(input);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write($"<html><head><body><h1>Best Game!!!</h1><p>{result.ToString()}</p></body></head></html>");

            }
        }
    }
}
