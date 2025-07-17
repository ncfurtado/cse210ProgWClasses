class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;

    public Reference()
    { }


    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
public static Scripture CreateCustomScripture()
{
    Console.Write("Enter the book name: ");
    string book = Console.ReadLine();
    
    Console.Write("Enter the chapter: ");
    string chapter = Console.ReadLine();

    Console.Write("Enter the starting verse: ");
    string startVerse = Console.ReadLine();

    Console.Write("Is this a verse range? (y/n): ");
    string isRange = Console.ReadLine().ToLower();
    
    Reference reference;
    if (isRange == "y")
    {
        Console.Write("Enter the ending verse: ");
        string endVerse = Console.ReadLine();
        reference = new Reference(book, chapter,  $"{startVerse}-{endVerse}");
    }
    else
    {
        reference = new Reference(book, chapter, startVerse);
    }
    
    Console.Write("Enter the scripture text: ");
    string text = Console.ReadLine();
    
    return new Scripture(text, reference);
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


    public string GetVerse()
    {
        return _verse;
    }
}

//     public void PickScripture()
//     // Pass a list of scriptures 
//     {

//     }
// 