using AdresInfoLib;
using System;

namespace AdresInfoConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("..:::Adres Info:::..");
            string path = @"D:\OneDrive\HoGent\Programmeren gevorderd\Opdrachten\VS\AdresInfo\adresInfo.txt";
            AdresInfoReader r = new AdresInfoReader(path);
            r.readData();
            r.printData("Berlare");
            Console.ReadLine();
        }
    }
}
