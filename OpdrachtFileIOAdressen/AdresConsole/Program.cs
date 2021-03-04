using AdresInfo;
using System;

namespace AdresConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("..:::Adres Info:::..");
            AdresDataProcessor r = new AdresDataProcessor();
            r.UnzipFile();
            r.Process();

            Console.WriteLine("####################\n#      DELETE      #\n####################");
            Console.ReadLine();
            r.Delete();
            Console.ReadLine();
        }
    }
}
