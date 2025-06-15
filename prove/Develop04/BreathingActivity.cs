using System.ComponentModel.DataAnnotations;

class BreathingActivity : Activity
{
    /// <summary>
    /// Help the user pace their breathing to have a session of deep breathing for a certain amount of time. They might find more peace and less stress through the exercise.
    /// </summary>
    private bool _breatheIn;
    protected string _startMessage = "Welcome to the Breathing Activity!";
    private string _breathingMessage = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    public BreathingActivity(bool _breatheIn, string breathingMessage, string duration, string description,
            string name, string endMessage) : base(duration, description, name, endMessage)
    {
        _duration = duration;
        _description = description;
        _name = name;
        _endMessage = endMessage;
    }
    public void ShowBreathingStartMessage()
    {
        Console.Clear();
        Console.Write($"{_startMessage}");
        DisplayStartMessage(_breathingMessage);
        
    }
    public void DisplayBreathingMessage(string breathingMessage)
    {
        Console.Write("How long, in seconds, would you like your session to be?");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("Get ready...");
        Activity.Spinner(5);
        Console.Clear();
    }

    public void NumberCountdown(int startNumber)
    {
        // DateTime startTime = DateTime.Now;
        // DateTime futureTime = startTime.AddSeconds(secDuration);
        // DateTime currentTime = DateTime.Now;
        // int[] numbersToFive = { 5, 4, 3, 2, 1 };

        // if (currentTime < futureTime)
        // {
        //     {
        //         foreach (int sec in numbersToFive)
        //         {
        //             Console.Write(sec);
        //             Thread.Sleep(1000);
        //             Console.Write("\b \b"); 
        //         }
        //     }
        // }
        for (int i = startNumber; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

    }
    public void Run()
    {

        DisplayBreathingMessage(_breathingMessage);
        Console.Write("Breathe In...");
        this.NumberCountdown(2);
        Console.Clear();
        Console.Write("Breathe Out...");
        this.NumberCountdown(5);
        Console.Clear();
        Console.Write("Breathe In...");
        this.NumberCountdown(5);
        Console.Clear();
        Console.Write("Breathe Out...");
        this.NumberCountdown(5);
        Console.Clear();






    }
}