using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    interface IFileAttributes
    {
        int Size { get; }
        bool IsReadonly { get; }
        bool IsArchive { get; }
        bool IsInfected { get; }
    }
}
