class Reference
{
    private string _book;
    private string _chapter;
    private int _verse;

    public Reference()
    {}

    
    public Reference(string book, string chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string GetReference()
    {

        return $"{GetBook()} {GetChapter()} : {GetVerse()}";
    }

    
    public string GetBook()
    {
        return _book;
    }
    
    
    public string GetChapter()
    {
        return _chapter;
    }
    public int GetVerse()
    {
        return _verse;
    }


    public void PickScripture()
    // Pass a list of scriptures 
    {

    }
}