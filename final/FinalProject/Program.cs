using System;

class Program
{
    static void Main(string[] args)
    {
        int menuChoice = -1;

        Console.WriteLine("Hello FinalProject World!");

        DisplayMainMenu();
        Console.Write("Select a choice from the menu: ");
        menuChoice = int.Parse(Console.ReadLine());
        switch (menuChoice)
        {

            case 1:
                break;

            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;

        }
    }
    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Weekly Assignment Tracker ===");
        Console.WriteLine("1. View All Assignments");
        Console.WriteLine("2. Add New Assignment");
        Console.WriteLine("3. Mark Assignment Complete");
        Console.WriteLine("4. View Upcoming Assignments");
        Console.WriteLine("5. View Overdue Assignments");
        Console.WriteLine("6. Manage Courses");
        Console.WriteLine("7. View Calendar");
        Console.WriteLine("8. View Progress Report");
        Console.WriteLine("9. Exit");
        Console.Write("Select an option: ");
    }
}