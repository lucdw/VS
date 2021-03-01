using System;
using System.Collections.Generic;
using System.Text;

namespace Party
{
    public class BirthdayParty : party
    {
        private readonly double _boodschapPrijsStuk = 0.25;
        private readonly int[] _prijstTaart = { 40, 75 };

        #region Properties

        public String Boodschap { get; }

        #endregion

        #region Constructor

        public BirthdayParty(int aantal, bool versiering, string boodschap = null) : base(aantal, versiering)
        {
            Boodschap = boodschap;
        }

        #endregion

        #region Public

        public override double totaalKost()
        {
            double kost = base.totaalKost();
            kost += KostTaart();
            kost += BoodschapKost();
            return kost;
        }
        public override string ToString()
        {
            string msg = base.ToString();
            if (GroteTaart()) msg += "\n\tDe taart is 40cm.";
            else msg += "\n\tDe taart is 20cm.";
            if (String.IsNullOrEmpty(Boodschap)) msg += "\n\tGeen boodschap op de taart.";
            else msg += "\n\tBoodschap: " + Boodschap;
            return msg;
        }

        #endregion

        #region Private

        private bool GroteTaart()
        {
            if (AantalPersonen > 4) return true;
            else return false;
        }

        private int KostTaart()
        {
            if (GroteTaart()) return _prijstTaart[1];
            else return _prijstTaart[0];
        }

        private double BoodschapKost()
        {
            if (!String.IsNullOrEmpty(Boodschap))
            {
                String msg = Boodschap;
                if (GroteTaart())
                {
                    if (msg.Length > 40) return (msg.Substring(0, 40).Replace(" ", "").Length * _boodschapPrijsStuk);
                    else return (msg.Replace(" ", "").Length * _boodschapPrijsStuk);
                }
                else
                {
                    if (msg.Length > 16) return (msg.Substring(0, 16).Replace(" ", "").Length * _boodschapPrijsStuk);
                    else return (msg.Replace(" ", "").Length * _boodschapPrijsStuk);
                }
            }
            else return 0;
        }

        #endregion
    }
}
