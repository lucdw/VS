using System;
using System.Collections.Generic;
using System.Text;

namespace Geld
{
    public class Cash : Geld
    {
        public Cash(string eigenaar, double som) : base(eigenaar, som)
        {

        }
        public override void SpendeerGeld(double hoeveel)
        {
            base.SpendeerGeld(hoeveel);
            Console.WriteLine("uit uw portefeuille!");
        }
        public void SchrijfOver(Bank bank, double hoeveel)
        {
            Som -= hoeveel;
            bank.StortGeld(hoeveel);
            Console.WriteLine($"U storte {hoeveel} euro op de bank.");
            Console.WriteLine($"U heeft nog {Som} euro cash op zak.");
        }
        public void VoegGeldToe(double hoeveel)
        {
            Som += hoeveel;
        }
        public override string ToString()
        {
            return base.ToString() + " Euro bij zich!";
        }
    }
}
