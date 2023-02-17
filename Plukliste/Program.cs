using Plukliste.Infrastukture.console;

namespace Plukliste;

class PluklisteProgram {

    public static char readKey = ' ';
    public static string invoiceNumber = " ";
    public static Pluklist plukListe = new();
    private static Logging _logging = new Logging();
    private static LoggingColor _LoggingColor = new LoggingColor();
    private static LogginOptions _LogginOptions = new LogginOptions();
    static void Main()
    {
        Directory.CreateDirectory("import");

        if (!Directory.Exists("export"))
        {
            Directory.CreateDirectory("export");
            _logging.Log("created a export directory");
        }
        List<string> files = Directory.EnumerateFiles("export").ToList();

        var currentFileIndex = -1;
        while (Char.ToUpper(readKey) != 'Q')
        {
            if (files.Count == 0)
            {
                _logging.Log("No files found.");
            }
            else
            {
                if (currentFileIndex == -1) currentFileIndex = 0;
                FileStream file = File.OpenRead(files[currentFileIndex]);
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
                plukListe = (Pluklist?)xmlSerializer.Deserialize(file)!;
                _logging.Log($"Plukliste {currentFileIndex + 1} af {files.Count}");
                _logging.Log($"\nfile: {files[currentFileIndex]}");
                invoiceNumber = files[currentFileIndex].Substring(files[currentFileIndex].LastIndexOf('\\'));
                invoiceNumber = invoiceNumber.Replace("_export.XML", "");
                invoiceNumber = invoiceNumber.Remove(0, 1);
                PrintPlukliste(plukListe!);
                file.Close();
            }
            _logging.Log("\n\nOptions:");

            _LogginOptions.PrintOptions("Q", "uit");
            if (currentFileIndex >= 0) _LogginOptions.PrintOptions("A", "fslut plukseddel");
            if (currentFileIndex > 0) _LogginOptions.PrintOptions("F", "orrige plukseddel");
            if (currentFileIndex < files.Count - 1) _LogginOptions.PrintOptions("N", "æste plukseddel");
            _LogginOptions.PrintOptions("G", "enindlæs pluksedler");

            SwitchCase(ref files, ref currentFileIndex);
            _LoggingColor.Color(ConsoleColor.White);
        }
    }

    public static void PrintPlukliste(Pluklist plukliste)
    {
        if (plukliste != null && plukliste.Lines != null)
        {
            Console.WriteLine("\n{0,-13 }{1}", "Name:", plukliste.Name);
            Console.WriteLine("{0,-13 }{1}", "Forsendelse:", plukliste.Forsendelse);
            Console.WriteLine("{0,-13 }{1}", "Adresse:", plukliste.Adresse);

            Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
            foreach (var item in plukliste.Lines)
            {
                Console.WriteLine("{0,-7}{1,-9}{2,-20}{3}", item.Amount, item.Type, item.ProductID, item.Title);
            }
        }
    }

    private static void SwitchCase(ref List<string> files, ref int currentFileIndex)
    {
        readKey = Console.ReadKey().KeyChar;
        Console.Clear();
        _LoggingColor.Color(ConsoleColor.Red);
        switch (Char.ToUpper(readKey))
        {
            case 'G':
                files = Directory.EnumerateFiles("export").ToList();
                currentFileIndex = -1;
                _logging.Log("Pluklister genindlæst");
                break;
            case 'F':
                if (currentFileIndex > 0) currentFileIndex--;
                break;
            case 'N':
                if (currentFileIndex < files.Count - 1) currentFileIndex++;
                break;
            case 'A':
                var filewithoutPath = files[currentFileIndex].Substring(files[currentFileIndex].LastIndexOf('\\'));
                try { 
                File.Move(files[currentFileIndex], string.Format(@"import\\{0}", filewithoutPath));
                }
                catch {
                    _logging.Log("Faktura allerede afsluttet!");
                    files.Remove(files[currentFileIndex]);
                    break;
                }
                _logging.Log($"Plukseddel {files[currentFileIndex]} afsluttet.");
                files.Remove(files[currentFileIndex]);
                if (currentFileIndex == files.Count) currentFileIndex--;
                var handlesHTML = HandleHTML.HTMLHandler.PrintHTML;
                handlesHTML(invoiceNumber, plukListe);
                break;
        }
    }
}

