namespace FileManager
{
    internal interface IWordCounter
    {
        int NumberOfWords { get; }
        int NumberOfPages { get; }
        string Indexator(int placeWord);

    }
}