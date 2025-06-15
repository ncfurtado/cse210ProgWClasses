class Reference
{
    private Word[] _words;
    public Reference(string text)
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
}