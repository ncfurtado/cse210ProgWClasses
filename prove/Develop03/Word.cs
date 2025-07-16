class Word
{
    private string _text;
    private bool _visible;
    public Word(string text)
    {
        _text = text;
        _visible = true;
    }
    public void MakeInvisible()
    {
        _visible = false;
    }

    
    public bool GetVisibility()
    {
        return _visible;
    }

    public string Display()
    {
        if (GetVisibility() == true)
        {
            return _text;
        }
        return //underscores
        // Return the number of underscores as long as the word
    }
}