using Plukliste.Infrastukture.console.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    internal class SwitchCaseClass
    {
        public static void SwitchCase(ref List<string> files, ref int currentFileIndex, string invoiceNumber, Pluklist plukListe)
        {
            Logging logging = new Logging();
            LoggingColor loggingColor = new LoggingColor();

            char readKey = Console.ReadKey().KeyChar;
            Console.Clear();
            loggingColor.Color(ConsoleColor.Red);
            switch (Char.ToUpper(readKey))
            {
                case 'G':
                    files = Directory.EnumerateFiles("export").ToList();
                    currentFileIndex = -1;
                    logging.Log("Pluklister genindlæst");
                    break;
                case 'F':
                    if (currentFileIndex > 0) currentFileIndex--;
                    break;
                case 'N':
                    if (currentFileIndex < files.Count - 1) currentFileIndex++;
                    break;
                case 'A':
                    UpdateStorage(plukListe);
                    var filewithoutPath = files[currentFileIndex].Substring(files[currentFileIndex].LastIndexOf('\\'));
                    try
                    {
                        File.Move(files[currentFileIndex], string.Format(@"import\\{0}", filewithoutPath));
                    }
                    catch
                    {
                        logging.Log("Faktura allerede afsluttet!");
                        files.Remove(files[currentFileIndex]);
                        break;
                    }
                    logging.Log($"Plukseddel {files[currentFileIndex]} afsluttet.");
                    files.Remove(files[currentFileIndex]);
                    if (currentFileIndex == files.Count) currentFileIndex--;
                    var handlesHTML = HandleHTML.HTMLHandler.PrintHTML;
                    handlesHTML(invoiceNumber, plukListe);
                    break;
            }
        }

        public static void UpdateStorage(Pluklist plukListe)
        {
            Lager_dal.LagerData Lager = new();
            foreach (var item in plukListe.Lines)
            {
                if (Lager.GetProductCount(item.ProductID) > 0)
                {
                    Lager.UpdateProduct(item.ProductID, item.Title, Lager.GetProductCount(item.ProductID) - item.Amount);
                }
            }
        }
    }
}
