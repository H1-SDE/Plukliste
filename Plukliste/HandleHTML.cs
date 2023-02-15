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

        public static void HandlesHTML(string invoiceNumber, Pluklist pluklist)
        {
            string filePath = "";

            foreach (var item in pluklist.Lines)
            {
                if (item.Type == ItemType.Print)
                {
                    filePath = $@"./templates/{item.ProductID}.html";
                }
            }

            string document = File.ReadAllText(filePath);
            string plukListen = "";
            foreach (var item in pluklist.Lines)
            {
                plukListen = $"{item.Title}: {item.Amount} \n <br/> \n {plukListen}";
            }

            document = document.Replace("[Adresse]", pluklist.Adresse).Replace("[Name]", pluklist.Name).Replace("[Plukliste]", plukListen);

            using (StreamWriter writer = File.CreateText($@"./print/{invoiceNumber}.html"))
            {
                writer.Write(document);
            }

        }   
        public static void WriteHTML() {}

        public static void ReplaceHTML() { }

    }
}
