using Plukliste;
using Plukliste.Infrastukture.console;

namespace Plukliste;

class PluklisteProgram {

    public static char readKey = ' ';
    public static string invoiceNumber = " ";
    public static Pluklist plukListe = new();
    static void Main()
    {
        Logging logging = new Logging();
        LoggingColor loggingColor = new LoggingColor();
        LogginOptions logginOptions = new LogginOptions();
        
        List<string> files = GetFilesOrCreateDirectory.GetFile();

        var currentFileIndex = -1;
        while (Char.ToUpper(readKey) != 'Q')
        {
            if (files.Count == 0)
            {
                logging.Log("No files found.");
            }
            else
            {
                if (currentFileIndex == -1) currentFileIndex = 0;
                FileStream file = File.OpenRead(files[currentFileIndex]);
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
                plukListe = (Pluklist?)xmlSerializer.Deserialize(file)!;
                logging.Log($"Plukliste {currentFileIndex + 1} af {files.Count}");
                logging.Log($"\nfile: {files[currentFileIndex]}");
                invoiceNumber = files[currentFileIndex].Substring(files[currentFileIndex].LastIndexOf('\\'));
                invoiceNumber = invoiceNumber.Replace("_export.XML", "");
                invoiceNumber = invoiceNumber.Remove(0, 1);
                PrintPluklisteClass.PrintPlukliste(plukListe!);
                file.Close();
            }
            logging.Log("\n\nOptions:");

            logginOptions.PrintOptions("Q", "uit");
            if (currentFileIndex >= 0) logginOptions.PrintOptions("A", "fslut plukseddel");
            if (currentFileIndex > 0) logginOptions.PrintOptions("F", "orrige plukseddel");
            if (currentFileIndex < files.Count - 1) logginOptions.PrintOptions("N", "æste plukseddel");
            logginOptions.PrintOptions("G", "enindlæs pluksedler");

            SwitchCaseClass.SwitchCase(ref files, ref currentFileIndex, invoiceNumber, plukListe);
            loggingColor.Color(ConsoleColor.White);
        }
    }
}

