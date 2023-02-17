using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console
{
    public class LogginOptions
    {
        public void PrintOptions(string option, string funtion)
        {
            LoggingColor loggingColor = new LoggingColor();
            loggingColor.Color(ConsoleColor.Green);
            Console.Write(option);
            loggingColor.Color(ConsoleColor.White);
            Console.WriteLine(funtion);
        }
    }
}
