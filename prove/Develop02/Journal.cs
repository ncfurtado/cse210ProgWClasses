class Journal
{
    public List<Entry> _entries;
    public string _filename;

    public void Display()
    {

    }
    public void SaveJournal(string _response  )
    {

        Console.Write("What is the filename?: ");
        _filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(_filename, true))
        {
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            outputFile.WriteLine("This will be the first line in the file.");
            outputFile.WriteLine($"Date: {dateText}");
            outputFile.WriteLine($"{_response},");  
        }
    }
    public void LoadJournal()
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string firstName = parts[0];
            string lastName = parts[1];
        }
    }
}