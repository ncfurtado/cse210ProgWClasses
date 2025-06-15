using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
        Menu();
    }
    public static void Menu()
    {
        Console.WriteLine("Menu Options: ");
        Console.WriteLine("1. Start Breathing Activity ");
        Console.WriteLine("2. Start Reflection Activity ");
        Console.WriteLine("3. Start Listing Activity ");
        Console.WriteLine("4. Quit");
        try
        {
            Console.Write("Select a choice from the menu: ");
            int menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {

                case 1:
                    // Breathing Activity
                    BreathingActivity breathingActivity1 = new BreathingActivity(true,"2", "testing", "Testing Activity", "Tchau", "brubh" );
                    breathingActivity1.ShowBreathingStartMessage();
                    breathingActivity1.Run();
                    break;

                case 2:
                    // Reflection Activity
                    break;

                case 3:
                    // Listing Activity

                    Activity testing = new Activity("2", "testing", "Testing Activity", "Tchau");
                    Activity.Spinner(5);
                    break;

                case 4:
                    // Quit
                    Console.WriteLine("Thank you!");
                    Environment.Exit(0);
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}