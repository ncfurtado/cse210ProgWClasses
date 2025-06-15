using System.Security.Cryptography.X509Certificates;

public class Activity
{
    protected string _duration;
    protected string _description;
    protected string _name;
    protected string _endMessage;

    public static void DisplayStartMessage(string startMessage)
    {
        Console.WriteLine($"{startMessage}");
    }

    public static void DisplayEndMessage(string duration, string name)
    {
        Console.WriteLine($"Well Done!");
        Console.WriteLine($"");
        Console.WriteLine($"You have completed another {duration} seconds of the {name} Activity.");
    }

    public static void Spinner(int secDuration)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(secDuration);
        DateTime currentTime = DateTime.Now;
        string[] arr = { "-", @"\", "|", "/", "-" };
        if (currentTime < futureTime)
        {
            foreach (string ch in arr)
            {
                Console.Write(ch);
                Thread.Sleep(750);
                Console.Write("\b \b");
            }
        }
    }
    public static int DurationPrompt()
    {
        Console.WriteLine("How long, in seconds, would you like for your session?");
        int duration = int.Parse(Console.ReadLine());
        return duration;
    }

    public Activity(string duration, string description, string name, string endMessage)
    {
        _duration = duration;
        _description = description;
        _name = name;
        _endMessage = endMessage;
    }
}