using Plukliste.Infrastukture.console.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    internal class CreateNewDirectoryIfNotExists
    {
        public static void CreateDirectory(string folder) 
        {
            Logging logging = new Logging();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                logging.Log($"created a {folder} directory");
            }
        }
    }
}
