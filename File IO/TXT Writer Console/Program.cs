using System;
using System.IO;

namespace TXT_Writer_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello writing your file @D:\\OneDrive\\HoGent\testProg.txt :D");

            string path = @"D:\OneDrive\HoGent\testProg.txt";
            using (StreamWriter sw = new StreamWriter(path, false)) //False replace file with new empty && True append file
            {
                for (int i = 1; i < 11; i++)
                {
                    sw.WriteLine($"This is line {i} in the file");
                }
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.ReadLine();
        }
    }
}
