using System.Collections.Generic;

namespace AdresDataProcessing
{
    public class ProvincieGemeente
    {
        #region Properties

        public string TaalCodeProvincieNaam { get; set; }
        public string ProvincieNaam { get; set; }
        public string GemeenteNaam { get; set; }
        public SortedSet<string> StraatNamen { get; set; }
        #endregion

        #region Constructor

        public ProvincieGemeente(string provincieNaam)
        {
            ProvincieNaam = provincieNaam;
            StraatNamen = new SortedSet<string>();
        }

        #endregion

        #region Public

        public override string ToString()
        {
            string msg = null;
            foreach (var straatnaam in StraatNamen)
            {
                msg += $"{ProvincieNaam},{GemeenteNaam},{straatnaam}\n";
            }

            return msg;
        }

        #endregion
    }
}
