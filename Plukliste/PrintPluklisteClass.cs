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

                Console.WriteLine("\n{0,-12}{1,-15}{2,-25}{3, -35}{4}", "Antal", "Lager (Rest)", "Type", "Produktnr.", "Navn");
                Lager_dal.LagerData Antal = new();
                foreach (var item in plukliste.Lines)
                {
                    int produktAntal = Antal.GetProductCount(item.ProductID);
                    string antalTekst = item.Type == ItemType.Fysisk ? produktAntal >= 0 ? $"{produktAntal} ({produktAntal - item.Amount})" : "(N/A)" : "";
                    Console.WriteLine("{0,-12}{1,-15}{2,-25}{3, -35}{4}", item.Amount, $"{antalTekst}", item.Type, item.ProductID, item.Title);
                }
            }
        }
    }
}
