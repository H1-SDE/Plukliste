using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console.Interface
{
    internal class LogginFormat : ILoggingFormat
    {
        public void loggingFormat(string format, string text, string plukliste)
        {
            Console.WriteLine(format, text, plukliste);
        }
    }
}
