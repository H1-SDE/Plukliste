using Aspose.Html.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    internal class Logging
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintOptions(string option, string funtion)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(option);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(funtion);
        }

        public void Color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
