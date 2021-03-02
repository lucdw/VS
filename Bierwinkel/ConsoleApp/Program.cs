using BierWinkel;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Johny's Bierwinkel");

            Bier b1 = new Bier(1.05, "palm",Bierkleur.bruin, "palm", 25, 5.2, Setgrootte.zes);

            Inventaris inventaris = new Inventaris();
            inventaris.VoegBierToe(1.05, "palm", Bierkleur.bruin, "palm", 25, 5.2, Setgrootte.zes);
            inventaris.VoegBierToe(1.25, "rodenbach classic", Bierkleur.amber, "palm", 25, 5.2, Setgrootte.zes);
            inventaris.VoegBierToe(1.6, "leffe bruin", Bierkleur.bruin, "leffe", 33, 6.2, Setgrootte.zes);
            inventaris.VoegBierToe(1.8, "duvel", Bierkleur.blond, "duvel moortgat", 33, 8.5, Setgrootte.vier);

            Console.WriteLine("");
            Console.WriteLine("1ste Bier:");
            Bier x = inventaris.SelecteerBier("palm");
            Console.WriteLine($"{x}");

            Console.WriteLine("");
            Console.WriteLine("2de Bier:");
            Bier y = inventaris.ZoekBier(b1);
            Console.WriteLine($"{y}");

            Console.ReadLine();
        }
    }
}
