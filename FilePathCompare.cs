using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class FilePathCompare:IComparer<MyFile>
    {
        public int Compare(MyFile mf1,MyFile mf2)
        {
            return mf1.FilePath.CompareTo(mf2.FilePath);
        }
    }
}
