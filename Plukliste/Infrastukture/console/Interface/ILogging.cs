using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console.Interface
{
    public interface ILogging
    {
        void Log(string message);
        void Color(ConsoleColor color);
        void PrintOptions(string option, string funtion);
        void loggingFormat(string format, string text, string plukliste);
    }
}
