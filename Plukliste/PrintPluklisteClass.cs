using Plukliste.Infrastukture.console.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

                Console.WriteLine("\n{0,-13}{1,-19}{2,-30}{3}", "Antal", "Type", "Produktnr.", "Navn");
                Lager_dal.LagerData Antal = new();
                foreach (var item in plukliste.Lines)
                {
                    int produktAntal = Antal.GetProductCount(item.ProductID);
                    string antalTekst = item.Type == ItemType.Fysisk ? produktAntal >= 0 ? $"({produktAntal - item.Amount})" : "(N/A)" : "";
                    Console.WriteLine("{0,-13}{1,-19}{2,-30}{3}", ($"{item.Amount} {antalTekst}"), item.Type, item.ProductID, item.Title);
                }
            }
        }
    }
}
