using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console.Interface
{
    public class LogginOptions : ILoggingOptions
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
