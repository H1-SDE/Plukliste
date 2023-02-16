using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.HandleHTML
{
    public class HTMLCreator
    {
        string document;
        string invoiceNumber;

        public HTMLCreator(string document, string invoiceNumber)
        {
            this.document = document;
            this.invoiceNumber = invoiceNumber;
        }

        public static void CreateHTMLFile(string document, string invoiceNumber)
        {
            using StreamWriter writer = File.CreateText($@"./print/{invoiceNumber}.html");
            writer.Write(document);
        }
    }
}
