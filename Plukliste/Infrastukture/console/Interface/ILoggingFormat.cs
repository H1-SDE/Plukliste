using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console.Interface
{
    internal interface ILoggingFormat
    {
        void loggingFormat(string format, string text, string plukliste);
    }
}
