namespace Plukliste;

class PluklisteProgram {

    public static ConsoleColor standardColor = Console.ForegroundColor;

    static void Main()
    {

        Directory.CreateDirectory("import");

        if (!Directory.Exists("export"))
        {
            Console.WriteLine("Directory \"export\" not found");
            Console.ReadLine();
            return;
        }

        List<string> files = Directory.EnumerateFiles("export").ToList();

        char readKey = ' ';
        var index = -1;
        while (readKey != 'Q')
        {
            if (files.Count == 0)
            {
                Console.WriteLine("No files found.");
            }
            else
            {
                if (index == -1) index = 0;
                Console.WriteLine($"Plukliste {index + 1} af {files.Count}");
                Console.WriteLine($"\nfile: {files[index]}");

                FileStream file = File.OpenRead(files[index]);
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
                var plukliste = (Pluklist?)xmlSerializer.Deserialize(file);

                if (plukliste != null && plukliste.Lines != null)
                {
                    Console.WriteLine("\n{0, -13}{1}", "Name:", plukliste.Name);
                    Console.WriteLine("{0, -13}{1}", "Forsendelse:", plukliste.Forsendelse);
                    Console.WriteLine("{0, -13}{1}", "Adresse:", plukliste.Adresse);

                    Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
                    foreach (var item in plukliste.Lines)
                    {
                        Console.WriteLine("{0,-7}{1,-9}{2,-20}{3}", item.Amount, item.Type, item.ProductID, item.Title);
                    }
                }
                file.Close();
            }
            Console.WriteLine("\n\nOptions:");

            _printOptions("Q", "uit");
            if (index >= 0) _printOptions("A", "fslut plukseddel");
            if (index > 0) _printOptions("F", "orrige plukseddel");
            if (index < files.Count - 1) _printOptions("N", "æste plukseddel");
            _printOptions("G", "enindlæs pluksedler");

            readKey = Console.ReadKey().KeyChar;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            switch ( Char.ToUpper(readKey))
            {
                case 'G':
                    files = Directory.EnumerateFiles("export").ToList();
                    index = -1;
                    Console.WriteLine("Pluklister genindlæst");
                    break;
                case 'F':
                    if (index > 0) index--;
                    break;
                case 'N':
                    if (index < files.Count - 1) index++;
                    break;
                case 'A':
                    var filewithoutPath = files[index].Substring(files[index].LastIndexOf('\\'));
                    File.Move(files[index], string.Format(@"import\\{0}", filewithoutPath));
                    Console.WriteLine($"Plukseddel {files[index]} afsluttet.");
                    files.Remove(files[index]);
                    if (index == files.Count) index--;
                    break;
            }
            Console.ForegroundColor = standardColor;
        }
    }

    private static void _printOptions(string option, string funtion)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(option);
        Console.ForegroundColor = standardColor;
        Console.WriteLine(funtion);
    }
}
