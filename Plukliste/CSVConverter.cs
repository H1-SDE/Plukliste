using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    public class CSVConverter : ICSVConverter
    {
        public void CSVReader(FileStream file, Pluklist plukListe)
        {
            using (var reader = new StreamReader(file))
            {
                plukListe.Name = $"{file.Name.Split("_")[1]} {file.Name.Split("_")[2].Replace(".CSV", "")}";
                plukListe.Forsendelse = "PickUp";
                string file_text = reader.ReadToEnd();

                string[] data = file_text.Split(new char[] { ';', '\n' });

                AddToList(plukListe, data);
            }
        }

        public void AddToList(Pluklist plukListe, string[] data)
        {
            plukListe.Lines.Clear();

            for (int row = 4; row < data.Length - 1; row += 4)
            {
                Item item = new()
                {
                    ProductID = data[row],
                    Type = data[row + 1] == "Fysisk" ? (ItemType)0 : data[row + 2] == "Print" ? (ItemType)1 : (ItemType)2,
                    Title = data[row + 2],
                    Amount = Convert.ToInt32(data[row + 3])
                };
                plukListe.Lines.Add(item);
            }
        }
    }
}
