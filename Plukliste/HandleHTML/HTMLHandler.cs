using Aspose.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste.HandleHTML
{
    internal class HTMLHandler
    {
        public static void PrintHTML(string invoiceNumber, Pluklist pluklist)
        {
            foreach (var item in pluklist.Lines)
            {
                if (item.Type == ItemType.Print)
                {
                    string filePath = $@"./templates/{item.ProductID}.html";

                    string document = HTMLWriter.WriteHTML(pluklist, filePath);
                    HTMLCreator.CreateHTMLFile(document, invoiceNumber);
                }
            }
        }
    }
}
