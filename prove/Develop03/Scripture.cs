class Scripture
{
    private string _reference;
    private List<Reference> _verses;
    public Scripture(string reference, List<string> verses)
    {
        _reference = reference;
        _verses = new List<Reference>();
        foreach (string verse in verses)
        {
            _verses.Add(new Reference(verse));
        }
    }

    public Scripture(StreamReader reader)
    {
        _reference = reader.ReadLine().Trim();
        while (!reader.EndOfStream)
        {
            string text = reader.ReadLine().Trim();
            _verses.Add(new Reference(text));
        }
    }

}