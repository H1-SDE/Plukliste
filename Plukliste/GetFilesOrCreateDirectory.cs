using Plukliste.Infrastukture.console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    internal class GetFilesOrCreateDirectory
    {
        public static List<string> GetFile()
        {
            CreateNewDirectoryIfNotExists.CreateDirectory("import");
            CreateNewDirectoryIfNotExists.CreateDirectory("export");

            List<string> files = Directory.EnumerateFiles("export").ToList();
            return files;
        }
    }
}
