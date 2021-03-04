using System;
using System.Collections.Generic;
using System.IO;

namespace AdresInfoLib
{
    public class AdresInfoReader
    {
        private string _path { get; }
        private string[] _adressen { get; set; }
        #region Constructor
        public AdresInfoReader(string path)
        {
            _path = path;
        }

        #endregion

        #region Public
        public void readData()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                string line;
                List<string> list = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
                _adressen = list.ToArray();
            }
        }

        public void printData(string stad)
        {
            int finalIndex = 0;
            List<string> list = new List<string>();
            foreach (string adres in _adressen)
            {
                string[] words = adres.Split(',');
                if (words[1].Equals(stad))
                {
                    list.Add(adres);
                }
            }
            list.Sort();

            foreach (string finalAdres in list)
            {
                Console.WriteLine(finalAdres);
            }
        }

        #endregion
    }
}
