﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.Infrastukture.console
{
    internal class LoggingColor
    { 

        public void Color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
