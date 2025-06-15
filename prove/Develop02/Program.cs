using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Menu();
    }
    static void Menu(){
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        int choice = int.Parse(Console.ReadLine());
        Entry usersEnrty = new Entry();
        Journal usersJournal = new Journal();

        switch (choice)
        {

            case 1:
                // Write
                
                break;

            case 2:
                // Display
                break;

            case 3:
                // Load
                break;

            case 4:
                // Save
                Journal.SaveJournal(_response);
                break;

            case 5:
                // Quit
                Console.WriteLine("Thank you!");
                Environment.Exit(0);
                break;
        }
    }
}