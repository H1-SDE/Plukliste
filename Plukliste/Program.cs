namespace Plukliste;

class PluklisteProgram {

    public static char readKey = ' ';

    static void Main()
    {
        Directory.CreateDirectory("import");

        if (!Directory.Exists("export"))
        {
            Directory.CreateDirectory("export");
            Console.WriteLine("created a export directory");
        }
        List<string> files = Directory.EnumerateFiles("export").ToList();

        var currentFileIndex = -1;
        while (Char.ToUpper(readKey) != 'Q')
        {
            if (files.Count == 0)
            {
                Console.WriteLine("No files found.");
            }
            else
            {
                if (currentFileIndex == -1) currentFileIndex = 0;
                Pluklist plukListe = FromXml(currentFileIndex, files).Item1;
                FileStream file = FromXml(currentFileIndex, files).Item2;
                Console.WriteLine($"Plukliste {currentFileIndex + 1} af {files.Count}");
                Console.WriteLine($"\nfile: {files[currentFileIndex]}");
                PrintPlukliste(plukListe);
                file.Close();
            }
            Console.WriteLine("\n\nOptions:");

            PrintOptions("Q", "uit");
            if (currentFileIndex >= 0) PrintOptions("A", "fslut plukseddel");
            if (currentFileIndex > 0) PrintOptions("F", "orrige plukseddel");
            if (currentFileIndex < files.Count - 1) PrintOptions("N", "æste plukseddel");
            PrintOptions("G", "enindlæs pluksedler");

            SwitchCase(ref files, ref currentFileIndex);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private static void PrintPlukliste(Pluklist plukliste)
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

    private static void PrintOptions(string option, string funtion)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(option);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(funtion);
    }

    private static (Pluklist, FileStream) FromXml(int currentFileIndex, List<string> files)
    {

        FileStream file = File.OpenRead(files[currentFileIndex]);
        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
        return ((Pluklist?)xmlSerializer.Deserialize(file), file);
    }

    private static void SwitchCase(ref List<string> files, ref int currentFileIndex)
    {
        readKey = Console.ReadKey().KeyChar;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        switch (Char.ToUpper(readKey))
        {
            case 'G':
                files = Directory.EnumerateFiles("export").ToList();
                currentFileIndex = -1;
                Console.WriteLine("Pluklister genindlæst");
                break;
            case 'F':
                if (currentFileIndex > 0) currentFileIndex--;
                break;
            case 'N':
                if (currentFileIndex < files.Count - 1) currentFileIndex++;
                break;
            case 'A':
                var filewithoutPath = files[currentFileIndex].Substring(files[currentFileIndex].LastIndexOf('\\'));
                File.Move(files[currentFileIndex], string.Format(@"import\\{0}", filewithoutPath));
                Console.WriteLine($"Plukseddel {files[currentFileIndex]} afsluttet.");
                files.Remove(files[currentFileIndex]);
                if (currentFileIndex == files.Count) currentFileIndex--;
                break;
        }
    }
}
