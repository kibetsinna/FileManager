using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        static void PrintList(List<MyFile> ListMyFile)
        {
            foreach (MyFile mfTemp in ListMyFile)
            {
                Console.WriteLine("Size :" + mfTemp.Size + " FilePath: " + mfTemp.FilePath);
            }
        }
        static void Main(string[] args)
        {
            WordFile wf = new WordFile("C:\\temp\\1.doc", 10000, true, false, 
                "I Love  .Net I Love .Net I Love .Net I I Love .Net I Love .Net I Love .Net I Love C++");
            wf.PrintFile();
            Console.WriteLine($"NumberOfWords: {wf.NumberOfWords}");
            Console.WriteLine($"NumberOfPages {wf.NumberOfPages}");
            Console.WriteLine(wf.Indexator(7));
            int[,] matrix = new int[4, 4];
            int z = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] =z+1;
                    z++;
                }
             
            }
            ImageFile imf=new ImageFile("C:\\temp\\2.jpg", 10000, true, false, matrix);
            ImageFile imf1 = new ImageFile("C:\\temp\\2.jpg", 10000, true, false, matrix);
            imf.PrintFile();
            //int myMalwareSize = Convert.ToInt32(ConfigurationManager.AppSettings["MalwareSize"]);
            //Console.WriteLine($"myMalwareSize: {VirusScanner.MyMalwareSize}");
            try 
            {
                WordFile wf2 = new WordFile("C:\\temp\\3.doc", -1, true, false, "aaa");
            }
            catch(InfectedFileDetectedException ex)
            {
               Console.WriteLine("InfectedFileDetectedException in file: "+ex.Message);
            }
            WordFile wf4 = new WordFile("C:\\temp\\4.doc", 1000, true, false,
               "I Love  .Net ");
            WordFile wf5 = new WordFile("C:\\temp\\2.doc", 800, true, false,
             "I Love  .Net ");
            WordFile wf6 = new WordFile("C:\\temp\\2.doc", 800, true, false,
            "I Love  .Net and C++ ");
            Console.WriteLine("******Print ALL List****** ");
            foreach (string mfs in MyFile.Paths)
            {
                Console.WriteLine(mfs);
            }
            new List<string>();
            List<MyFile> ListMyFile = new List<MyFile>();
            ListMyFile.Add(wf);
            ListMyFile.Add(wf4);
            ListMyFile.Add(wf5);
            Console.WriteLine("******Print List without sort*************");
            PrintList(ListMyFile);

            //Print Sort List(default)
            Console.WriteLine("******Print Sort List(default)*************");
            ListMyFile.Sort();
            PrintList(ListMyFile);
            //Print Sort List by Path
            Console.WriteLine("******Print Sort List by Path*************");
            FilePathCompare fpc = new FilePathCompare();
            ListMyFile.Sort(fpc);
            PrintList(ListMyFile);
            bool res = (wf4 == wf5);
            Console.WriteLine($"(Word file wf4 == Word file wf5) result ={res}");
            res = (imf == imf1);
            Console.WriteLine($"(Image file imf == Image file imf1) result ={res}");
            WordFile wf7 = wf4 + wf6;
            wf7.PrintFile();
            Console.WriteLine(wf.GetSpecipicWorsCount("Love"));
            Console.ReadLine();
        }
    }
}
