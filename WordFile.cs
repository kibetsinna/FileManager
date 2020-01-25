using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class WordFile : MyFile ,IWordCounter,ISpecificWordCount
    {
        public string FileContents { get;  }
        private string[] tempArray;
        private Dictionary<string, int> words;
        public int NumberOfWords
        {
            get
            {
                
                return tempArray.Length  ;
            } 
        }
        public int NumberOfPages
        {
            get
            { return (int)((double)NumberOfWords/10+0.5); }
        }
        public string Indexator(int placeWord)
        {
            string result = "";
         
            if ( placeWord > 0 && placeWord<=NumberOfWords)
            {
                result=tempArray[placeWord-1];

            }
            return result;

         
        }
        
        public WordFile(string filePath, int size, bool isReadOnly, bool isArchive) : base(filePath, size, isReadOnly, isArchive)
        {
        }
        public WordFile(string filePath, int size, bool isReadOnly, bool isArchive, string fileContents) : base(filePath, size, isReadOnly, isArchive)
        {
            FileContents = fileContents;
            tempArray = FileContents.Split(' ');
            words=new Dictionary<string,int>();
            if (tempArray.Length != 0)
            {
                int res;
                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (words.TryGetValue(tempArray[i], out res) == false)
                        words[tempArray[i]] = 1;
                    else
                        words[tempArray[i]] = res+1;
                }
            }
        }
        public override void PrintFile()
        {
            /* if(tempArray.Length!=0)
             {
                 for (int i = 0; i < tempArray.Length; i++)
                     Console.WriteLine(tempArray[i]);
             }*/
            Console.WriteLine($"****Print Word File {FilePath}**********");
            Console.WriteLine(this);
            Console.WriteLine("**************");
        }

        public override string ToString()
        {
            string str = "";
            if (tempArray.Length != 0)
            {
                for (int i = 0; i < tempArray.Length; i++)
                    str+=tempArray[i]+'\n';
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            var wordFile = obj as WordFile;
            return this == wordFile;
        }
        public static bool operator ==(WordFile w1,WordFile w2)
        {
            if (ReferenceEquals(w1, null) && ReferenceEquals(w2, null))
            {
                return true;
            }
            if (ReferenceEquals(w1, null) || ReferenceEquals(w2, null))
            {
                return false;
            }
            return w1.FileContents==w2.FileContents;
        }
        public static bool operator !=(WordFile w1, WordFile w2)
        {
            return !(w1 == w2);
        }
        public override int GetHashCode()
        {
            return this.FileContents.GetHashCode();
        }

        public int GetSpecipicWorsCount(string word)
        {
            int result = 0;
            words.TryGetValue(word,out result);
            return result;
        }

        public static WordFile operator +(WordFile w1, WordFile w2)
        {
            int res = w1.FilePath.CompareTo(w2.FilePath);
            string newPath = (res >=0? w1.FilePath : w2.FilePath)+".mrg";
            bool newIsReadonly = (res >= 0 ? w1.IsReadonly : w2.IsReadonly);
            bool newIsArchive = (res >= 0 ? w1.IsArchive : w2.IsArchive);
            WordFile wf = new WordFile(newPath,w1.Size+w2.Size,newIsReadonly,newIsArchive,
                w1.FileContents+w2.FileContents);
            return wf;
          
        }
    }
}
