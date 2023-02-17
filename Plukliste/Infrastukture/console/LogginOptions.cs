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
            Console.ForegroundColor = LoggingColor.Green;
            Console.Write(option);
            Console.ForegroundColor = LoggingColor.White;
            Console.WriteLine(funtion);
        }
    }
}
