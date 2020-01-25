using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class ImageFile : MyFile
    {
        private int[,] matrixFile;
        public int[,] Matrix
        {
            get { return matrixFile; }
        }
        public ImageFile(string filePath, int size, bool isReadOnly, bool isArchive) : base(filePath, size, isReadOnly, isArchive)
        {
            this.matrixFile =null;
        }
        public ImageFile(string filePath, int size, bool isReadOnly, bool isArchive, int[,] matrixFile) : base(filePath, size, isReadOnly, isArchive)
        {
            this.matrixFile = matrixFile;
        }

        public override string ToString()
        {
            string str = "";
            if (matrixFile != null)
            {
                for (int i = 0; i < matrixFile.GetLength(0); i++)
                {
                    for (Int32 j = 0; j < matrixFile.GetLength(1); j++)
                    {
                        str+=matrixFile[i, j] + "\t";
                    }
                    str+= '\n';
                }
            }
            return str;
        }

        public override void PrintFile()
        {
            Console.WriteLine($"****Print Image File {FilePath}**********");
            Console.WriteLine(this);
            Console.WriteLine("**************");
        }
    }
  
}
