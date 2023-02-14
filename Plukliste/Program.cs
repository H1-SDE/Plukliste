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

        //ACT
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
                index = index == -1 ? 0 : index;

                Console.WriteLine($"Plukliste {index + 1} af {files.Count}");
                Console.WriteLine($"\nfile: {files[index]}");

                //read file
                FileStream file = File.OpenRead(files[index]);
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
                var plukliste = (Pluklist?)xmlSerializer.Deserialize(file);

                //print plukliste
                if (plukliste != null && plukliste.Lines != null)
                {
                    Console.WriteLine("\n{0, -13}{1}", "Name:", plukliste.Name);
                    Console.WriteLine("{0, -13}{1}", "Forsendelse:", plukliste.Forsendelse);
                    //TODO: Add adresse to screen print

                    Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
                    foreach (var item in plukliste.Lines)
                    {
                        Console.WriteLine("{0,-7}{1,-9}{2,-20}{3}", item.Amount, item.Type, item.ProductID, item.Title);
                    }
                }
                file.Close();
            }
            //Print options
            Console.WriteLine("\n\nOptions:");

            _printOptions("Q", "uit");
            if (index >= 0) _printOptions("A", "fslut plukseddel");
            if (index > 0) _printOptions("F", "orrige plukseddel");
            if (index < files.Count - 1) _printOptions("N", "æste plukseddel");
            _printOptions("G", "enindlæs pluksedler");

            readKey = Console.ReadKey().KeyChar;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red; //status in red
            switch ( Char.ToLower(readKey))
            {
                case 'g':
                    files = Directory.EnumerateFiles("export").ToList();
                    index = -1;
                    Console.WriteLine("Pluklister genindlæst");
                    break;
                case 'f':
                    if (index > 0) index--;
                    break;
                case 'n':
                    if (index < files.Count - 1) index++;
                    break;
                case 'a':
                    //Move files to import directory
                    var filewithoutPath = files[index].Substring(files[index].LastIndexOf('\\'));
                    File.Move(files[index], string.Format(@"import\\{0}", filewithoutPath));
                    Console.WriteLine($"Plukseddel {files[index]} afsluttet.");
                    files.Remove(files[index]);
                    if (index == files.Count) index--;
                    break;
            }
            Console.ForegroundColor = standardColor; //reset color
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
