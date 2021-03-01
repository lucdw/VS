using System;
using System.Collections.Generic;
using System.Text;

namespace BierWinkel
{
    public class Inventaris
    {
        private Dictionary<string, Bier> Biertjes = new Dictionary<string, Bier>();
        //public List<Bier> Biertjes = new List<Bier>();
        public void VoegBierToe(double prijsPerStuk, string naam, Bierkleur? kleur, string brouwerij, double volume, double alcoholPercentage, Setgrootte? minimumHoeveelheid)
        {
            Bier bier = new Bier(prijsPerStuk, naam, kleur, brouwerij, volume, alcoholPercentage, minimumHoeveelheid);
            if (!Biertjes.ContainsKey(naam)) Biertjes.Add(bier.Naam, bier);
        }

        public Bier SelecteerBier(string naam)
        {
            if (Biertjes.ContainsKey(naam)) return Biertjes[naam];
            return null;
        }

        public Bier ZoekBier(Bier bier)
        {
            List<Bier> gevondenBiertjes = new List<Bier>();
            foreach(Bier b in Biertjes.Values)
            {
                if (bier.Kleur != null && bier.Kleur != b.Kleur) continue;
                if (bier.Brouwerij != null && bier.Brouwerij.Length > 0 && bier.Brouwerij != b.Brouwerij) continue;
                if (bier.Volume > 0 && bier.Volume != b.Volume) continue;
                if (bier.AlcoholPercentage >= 0 && bier.AlcoholPercentage != b.AlcoholPercentage) continue;
                return b;
            }
            return null;
        }
    }
}
