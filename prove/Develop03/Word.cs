class Word
{
    private string _text;
    private bool _visible;

    // constructor
    public Word(string text)
    {
        _text = text;
        _visible = true;
    }

    public string GetText()
    {
        return _text;
    }

    public void Hide()
    {
        _text = new string('_', _text.Length);
        _visible = false;

    }


    
    public bool GetVisibility()
    {
        return _visible;
    }

    public string Display()
    {
        if (GetVisibility())
        {
            return _text;
        }
        else
        {
            return new string('_', _text.Length);
            // Return underscores for invisible words
        }
    }
}