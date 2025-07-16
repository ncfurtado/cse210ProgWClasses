class Scripture
{
    private string _scriptureText;
    private Reference _reference;
    // private List<Reference> _verses;
    private Word[] _words;


    // public Scripture(string reference, List<string> verses)
    // {
    //     _reference = reference;
    //     _verses = new List<Reference>();
    //     foreach (string verse in verses)
    //     {
    //         _verses.Add(new Reference(verse));
    //     }
    // }
    public Scripture()
    { }

    public Scripture(string text, Reference reference)
    {
        string[] parts = text.Split();
        // Split the text of the verse into individual words.

        _words = new Word[parts.Length];
        // Create an array of words.

        for (int i = 0; i < parts.Length; i++)
        {
            _words[i] = new Word(parts[i]);
        }
    }
    public void DisplayScripture()
    {
        Console.WriteLine(_reference.GetReference());
    }

    
    public void HideWords()
    {
        for (int i = 0; i < _words; i++)
    }


    public bool IsCompletelyInvisible()
    {
        for ()
        {
            if GetVisibility()

        }
    }
}