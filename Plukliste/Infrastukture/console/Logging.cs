using Aspose.Html.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console.Interface
{
    public class Logging : ILogging
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintOptions(string option, string funtion)
        {
            LoggingColor loggingColor = new LoggingColor();
            loggingColor.Color(ConsoleColor.Green);
            Console.Write(option);
            loggingColor.Color(ConsoleColor.White);
            Console.WriteLine(funtion);
        }

        public void Color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void loggingFormat(string format, string text, string plukliste)
        {
            Console.WriteLine(format, text, plukliste);
        }
    }
}
