using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    internal class HandleHTML
    {
        public string nameOfFile { get; set; }

        public static void HandlesHTML(string InvoiceNumber, Pluklist pluklist)
        {
            foreach (var item in pluklist.Lines)
            {
                if (item.Type == ItemType.Print) Console.WriteLine(item.ProductID);
            }
        }
        public static void WriteHTML() {}

        public static void ReplaceHTML() { }

    }
}
