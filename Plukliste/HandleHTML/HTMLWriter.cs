using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.HandleHTML
{
    internal class HTMLWriter
    {
        Pluklist pluklist;
        string filePath;

        public HTMLWriter(Pluklist pluklist, string filePath)
        {
            this.pluklist = pluklist;
            this.filePath = filePath;
        }

        public static string WriteHTML(Pluklist pluklist, string filePath)
        {
            string document = File.ReadAllText(filePath);
            string plukListen = "";
            foreach (var item in pluklist.Lines)
            {
                plukListen = $"{item.Title}: {item.Amount} \n <br/> \n {plukListen}";
            }

            document = document.Replace("[Adresse]", pluklist.Adresse).Replace("[Name]", pluklist.Name).Replace("[Plukliste]", plukListen);

            return document;
        }
    }
}
