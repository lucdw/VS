using System;

namespace Party
{
    public abstract class party
    {
        private bool versieringLuxe { get; set; }

        #region Properties

        public int AantalPersonen { get; set; }

        #endregion

        #region Constructor

        public party(int aantal, bool versiering)
        {
            AantalPersonen = aantal;
            versieringLuxe = versiering;
        }

        #endregion

        #region Public

        public virtual double totaalKost()
        {
            double kost = 0;
            kost += basisKost();
            kost += etensKost();
            kost += decoratieKost();
            return kost;
        }
        public override string ToString()
        {
            string msg = "Feestje:\n\tKost: " + totaalKost().ToString() + " euro.";
            if (versieringLuxe) msg += "\n\tInclusief luxe versiering.";
            else msg += "\n\tExclusief luxe versiering.";
            return msg;
        }

        #endregion

        #region Private

        private int basisKost()
        {
            if (AantalPersonen > 12)
            {
                return 100;
            }
            else return 0;
        }
        private int etensKost()
        {
            return (AantalPersonen * 25);
        }
        private double decoratieKost()
        {
            double result;
            if (versieringLuxe)
            {
                result = 50 + (15 * AantalPersonen);
            }
            else
            {
                result = 30 + (7.5 * AantalPersonen);
            }
            return result;
        }


        #endregion
    }
}
