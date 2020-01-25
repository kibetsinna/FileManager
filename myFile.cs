using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal abstract class MyFile : IFileAttributes, IComparable
    {
        private readonly string filePath;
        private int size;
        private bool isReadOnly;
        private bool isArchive;
        private bool isInfected;
        private const bool isHebrowSupported = true;
        public abstract void PrintFile();

        public int CompareTo(object obj)
        {
            MyFile mf = obj as MyFile;
            if (mf != null)
                return this.Size.CompareTo(mf.Size);
            else
                throw new Exception("Not possible to compare!");
        }

        private static List<string> paths;
        public string FilePath
        {
            get { return filePath; }
        }
        public int Size
        {
            get { return size; }

            set { size = value; }
        }
        public bool IsReadonly
        {
            get { return isReadOnly; }

            set { isReadOnly = value; }
        }
        public bool IsArchive
        {
            get { return isArchive; }

            set { isArchive = value; }
        }
        public bool IsInfected
        {
            get { return isInfected; }

            //set { isInfected = value; }
        }
        public static List<string> Paths => paths;
        public MyFile(string filePath, int size, bool isReadOnly, bool isArchive)
        {
            this.filePath = filePath;
            this.size = size;
            this.isReadOnly = isReadOnly;
            this.isArchive = isArchive;
            this.isInfected = VirusScanner.IsFileInfected(this);
            if (this.IsInfected)
                throw new InfectedFileDetectedException(this.FilePath);
            if (paths == null)
                paths = new List<string>();
            paths.Add(filePath);
        }
        public override bool Equals(object obj)
        {
            var myFile = obj as MyFile;
            return this == myFile;
        }
        public static bool operator ==(MyFile m1, MyFile m2)
        {
            if (ReferenceEquals(m1, null) && ReferenceEquals(m2, null))
            {
                return true;
            }
            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null))
            {
                return false;
            }
            return m1.FilePath==m2.FilePath;
        }
        public static bool operator !=(MyFile m1, MyFile m2)
        {
            return !(m1 == m2);
        }
        public override int GetHashCode()
        {
            return this.FilePath.GetHashCode();
        }
    }   
 }
