class Scripture
{
    private string _text;
    private Reference _reference;
    private List<Word> _words;

    public Scripture()
    { }

    public Scripture(string text, Reference reference)
    {
        _text = text;
        _reference = reference;
        _words = new List<Word>();
        string[] parts = _text.Split();

        for (int i = 0; i < parts.Length; i++)
        {
            _words.Add(new Word(parts[i]));
        }
    }

    public void DisplayScripture()
    {
        Console.WriteLine(_reference.GetReference());
        foreach (Word word in _words)
        {
            Console.Write(word.GetText() + " "); // Assuming this returns either text or underscores
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        // Get available indexes (words that are still visible)
        List<int> availableIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].GetVisibility()) // Only add if word is still visible
            {
                availableIndexes.Add(i);
            }
        }

        // Hide 2-3 random words from available ones
        Random random = new Random();
        int wordsToHide = Math.Min(3, availableIndexes.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            if (availableIndexes.Count > 0)
            {
                int randomIndex = random.Next(availableIndexes.Count);
                int wordIndex = availableIndexes[randomIndex];

                _words[wordIndex].Hide(); // Hide the word
                availableIndexes.RemoveAt(randomIndex);
            }
        }
    }

    public bool IsCompletelyInvisible()
    {
        foreach (Word word in _words)
        {
            if (word.GetVisibility()) // If any word is still visible
            {
                return false;
            }
        }
        return true; // All words are hidden
    }
}