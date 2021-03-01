using System;
using Geld;

namespace ConsoleAppGeld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef uw naam:");
            string naam = Console.ReadLine();

            Console.WriteLine($"Hello {naam}!");
            Cash c = new Cash(naam, 500);
            Bank b = new Bank(naam, 5000);
            Console.WriteLine(c);
            Console.WriteLine(b);

            Console.WriteLine("------------------");
            c.SpendeerGeld(450);
            Console.WriteLine(c);
            Console.WriteLine("------------------");
            c.SchrijfOver(b, 50);
            Console.WriteLine("------------------");
            b.SpendeerGeld(4050);
            Console.WriteLine(b);
            Console.WriteLine("------------------");
            b.HaalGeldAf(c, 1000);
            Console.WriteLine("------------------");

            Console.WriteLine(c);
            Console.WriteLine(b);
            Console.ReadLine();
        }
    }
}
