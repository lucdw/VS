using AdresDataProcessing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace AdresInfo
{
    public class AdresDataProcessor
    {
        private string path;
        private string zip;
        private string pathExtract;
        private string pathResults;
        private string outputFileName;

        #region Constructor
        public AdresDataProcessor()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"adresfiles.json", false, true);
            var config = builder.Build();

            path = config["path"];
            zip = config["ZIP"];
            createDir(path, "extract");
            pathExtract = config["pathExtract"];
            createDir(path, "results");
            pathResults = config["pathResults"];
            outputFileName = config["outputFileName"];

        }
        #endregion

        #region Public

        public void Delete()
        {
            if (Directory.Exists(pathExtract))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Deleting directory {pathExtract}");
                Directory.Delete(pathExtract, true);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (Directory.Exists(pathResults))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Deleting directory {pathResults}");
                Directory.Delete(pathResults, true);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void Process()
        {
            foreach (var x in Data())
            {
                string provincie = x.Value.ProvincieNaam;
                string gemeente = x.Value.GemeenteNaam + ".txt";
                SortedSet<string> straten = x.Value.StraatNamen;

                writeTXTList(x.Value.ToString());

                createDir(pathResults, provincie);

                createTXT(Path.Combine(pathResults, provincie), gemeente, straten);

            }

            Console.WriteLine("All Files Created");
        }

        public void UnzipFile()
        {
            Console.WriteLine("\nExtracting Zip File to subdir Extract");
            string pathZip = Path.Combine(path, zip);
            using (ZipArchive archive = ZipFile.Open(pathZip, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(pathExtract + "\\" + entry.Name);
                }
            }
        }

        #endregion

        #region Private

        private Dictionary<int, ProvincieGemeente> Data()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"adresfiles.json", false, true);
            var Files = builder.Build();
            Console.WriteLine("start reading files\n");

            HashSet<int> provincieIds = new HashSet<int>();
            using (StreamReader p = new StreamReader(Path.Combine(pathExtract, Files["provincies"])))
            {
                string line = p.ReadLine();
                string[] x = line.Split(',');
                foreach (var y in x)
                {
                    provincieIds.Add(int.Parse(y));
                }
            }

            Dictionary<int, ProvincieGemeente> gemeenteProvincieLink = new Dictionary<int, ProvincieGemeente>();
            using (StreamReader gp = new StreamReader(Path.Combine(pathExtract, Files["provincieInfo"])))
            {
                string line;
                int prov;
                while ((line = gp.ReadLine()) != null)
                {
                    string[] x = line.Split(';');
                    if (int.TryParse(x[1], out prov) && x[2] == "nl")
                        if (provincieIds.Contains(prov))
                        {
                            gemeenteProvincieLink.Add(int.Parse(x[0]), new ProvincieGemeente(x[3]));
                        }
                }
            }

            using (StreamReader g = new StreamReader(Path.Combine(pathExtract, Files["gemeentenaam"])))
            {
                string line;
                int stadId;
                while ((line = g.ReadLine()) != null)
                {
                    string[] x = line.Split(';');
                    if (int.TryParse(x[1], out stadId) && x[2] == "nl")
                        if (gemeenteProvincieLink.ContainsKey(stadId))
                        {
                            gemeenteProvincieLink[stadId].GemeenteNaam = x[3];
                        }
                }
            }

            Dictionary<int, int> straatnaamGemeenteLink = new Dictionary<int, int>();
            using (StreamReader pg = new StreamReader(Path.Combine(pathExtract, Files["straatnaamgemeente"])))
            {
                string line;
                int stadId, straatId;
                while ((line = pg.ReadLine()) != null)
                {
                    string[] x = line.Split(';');
                    if (int.TryParse(x[0], out straatId) && int.TryParse(x[1], out stadId))
                        if (gemeenteProvincieLink.ContainsKey(stadId))
                        {
                            straatnaamGemeenteLink.Add(straatId, stadId);
                        }
                }
            }

            using (StreamReader s = new StreamReader(Path.Combine(pathExtract, Files["straatnaam"])))
            {
                string line;
                int straatId;
                while ((line = s.ReadLine()) != null)
                {
                    string[] x = line.Split(';');
                    if (int.TryParse(x[0], out straatId))
                        if (straatnaamGemeenteLink.ContainsKey(straatId))
                        {
                            int m = straatnaamGemeenteLink[straatId];
                            if (gemeenteProvincieLink.ContainsKey(m))
                                gemeenteProvincieLink[m].StraatNamen.Add(x[1]);
                        }
                }
            }

            Console.WriteLine("end reading files\n");

            return gemeenteProvincieLink;
        }

        private void createDir(string path, string subdir)
        {
            string p = Path.Combine(path, subdir);
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!Directory.Exists(p))
                Console.WriteLine($"Created dir:\"{subdir}\" at:\"{path}\"");
            dir.CreateSubdirectory(subdir);

        }

        private void createTXT(string path, string name, SortedSet<string> set)
        {
            Console.WriteLine($"Creating {name}");

            string txtPath = Path.Combine(path, name);
            using (StreamWriter sw = new StreamWriter(txtPath, true))
            {
                foreach (var x in set)
                {
                    sw.WriteLine(x.ToString());
                }

            }
        }

        private void writeTXTList(string listItem)
        {
            string path = Path.Combine(pathResults, outputFileName);
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(listItem);
            }
        }

        #endregion
    }
}
