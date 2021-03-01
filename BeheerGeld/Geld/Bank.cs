using System;
using System.Collections.Generic;
using System.Text;

namespace Geld
{
    public class Bank : Geld
    {
        public Bank(string eigenaar, double som) : base(eigenaar, som)
        {

        }
        public override void SpendeerGeld(double hoeveel)
        {
            base.SpendeerGeld(hoeveel);
            Console.WriteLine("van de bank!");
        }
        public void StortGeld(double hoeveel)
        {
            Som += hoeveel;
        }
        public void HaalGeldAf(Cash cash, double hoeveel)
        {
            Som -= hoeveel;
            cash.VoegGeldToe(hoeveel);
            Console.WriteLine($"U haalde {hoeveel} euro van de bank.");
            Console.WriteLine($"U heeft nog {Som} euro op de bank staan.");
        }
        public override string ToString()
        {
            return base.ToString() + " Euro op de bank staan!";
        }
    }
}
