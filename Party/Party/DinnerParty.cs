using System;
using System.Collections.Generic;
using System.Text;

namespace Party
{
    public class DinnerParty : party
    {
        private bool gezondeDranken { get; set; }

        #region Constructor

        public DinnerParty(int aantal, bool gezond, bool versiering) : base(aantal, versiering)
        {
            gezondeDranken = gezond;
        }

        #endregion

        #region Public

        public override double totaalKost()
        {
            double kost = base.totaalKost();
            kost += drankKost();
            if (gezondeDranken) kost *= 0.95;
            return kost;
        }
        public override string ToString()
        {
            string msg = base.ToString();
            if (gezondeDranken) msg += "\n\tExclusief alcohol.";
            else msg += "\n\tInclusief alcohol.";
            return msg;
        }

        #endregion

        #region Private

        private int drankKost()
        {
            if (gezondeDranken)
            {
                return (AantalPersonen * 5);
            }
            else return (AantalPersonen * 20);
        }

        #endregion

    }
}
