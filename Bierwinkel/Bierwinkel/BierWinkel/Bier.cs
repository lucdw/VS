using System;
using System.Collections.Generic;
using System.Text;

namespace BierWinkel
{
    public class Bier
    {
        public Bier(double prijsPerStuk, string naam, Bierkleur? kleur, string brouwerij, double volume, double alcoholPercentage, Setgrootte? minimumHoeveelheid)
        {
            if (prijsPerStuk <= 0) throw new Exception("prijs moet groter zijn dan 0");
            PrijsPerStuk = prijsPerStuk;
            if (string.IsNullOrWhiteSpace(naam)) throw new Exception("naam mag niet leeg zijn");
            Naam = naam;
            Kleur = kleur;
            Brouwerij = brouwerij;
            Volume = volume;
            if (alcoholPercentage < 0) throw new Exception("percentage kan niet kleiner zijn dan 0");
            AlcoholPercentage = alcoholPercentage;
            MinimumHoeveelheid = minimumHoeveelheid;
            
        }
        public override string ToString()
        {
            return $"{PrijsPerStuk} euro/stuk, Naam: {Naam}, Kleur: {Kleur}, Brouwerij: {Brouwerij}, Inhoud: {Volume}, Vol: {AlcoholPercentage}%, Min Hoeveelheid {MinimumHoeveelheid}";
        }
        public double PrijsPerStuk { get; private set; }
        public string Naam { get; private set; }
        public Bierkleur? Kleur { get; private set; }
        public string Brouwerij { get; private set; }
        public double Volume { get; private set; }
        public double AlcoholPercentage { get; private set; }
        public Setgrootte? MinimumHoeveelheid { get; private set; }
    }
}
