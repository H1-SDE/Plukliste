using Plukliste.Infrastukture.console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    internal class PrintPluklisteClass
    {
        public static void PrintPlukliste(Pluklist plukliste)
        {
            LogginFormat logginFormat = new LogginFormat();
            if (plukliste != null && plukliste.Lines != null)
            {
                logginFormat.loggingFormat("\n{0,-13 }{1}", "Name:", plukliste.Name);
                logginFormat.loggingFormat("{0,-13 }{1}", "Forsendelse:", plukliste.Forsendelse);
                logginFormat.loggingFormat("{0,-13 }{1}", "Adresse:", plukliste.Adresse);

                Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
                foreach (var item in plukliste.Lines)
                {
                    Console.WriteLine("{0,-7}{1,-9}{2,-20}{3}", item.Amount, item.Type, item.ProductID, item.Title);
                }
            }
        }
    }
}
