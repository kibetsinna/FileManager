using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal static class VirusScanner
    {
        public static int MyMalwareSize;
        
        static VirusScanner()
        {
            MyMalwareSize = Convert.ToInt32(ConfigurationManager.AppSettings["MalwareSize"]);
        }
        public static bool IsFileInfected(MyFile f)=> f.Size == MyMalwareSize;
   
    }
}
