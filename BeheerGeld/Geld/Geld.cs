using System;
using System.Collections.Generic;
using System.Text;

namespace Geld
{
    public abstract class Geld
    {
        public Geld(string eigenaar, double som)
        {
            Eigenaar = eigenaar;
            Som = som;
        }

        public string Eigenaar { get; set; }
        public double Som { get; set; }

        public virtual void SpendeerGeld(double hoeveel)
        {
            if (hoeveel <= Som)
            {
                Som -= hoeveel;
            }
            else throw new Exception("U heeft niet zoveel geld!");
            
            Console.Write($"U spendeerde {hoeveel} euro ");
        }

        public override string ToString()
        {
            return $"{Eigenaar} heeft {Som}";
        }
    }
}
