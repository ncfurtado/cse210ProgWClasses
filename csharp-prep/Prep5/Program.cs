using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        DisplayMessage();
        string username = PromptUserName();
        double number = PromptUserNumber();
        double squaredNumber = SquareNumber(number);
        DisplayResult(username, squaredNumber);
    }
    static void DisplayMessage ()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName ()
    {
        Console.WriteLine("What is your name?");
        string username = Console.ReadLine();
        return username;
    }
        static int PromptUserNumber ()
    {
        Console.WriteLine("What is your favorite number??");
        string userinput = Console.ReadLine();
        int number = int.Parse(userinput);
        return number;
    }
        static double SquareNumber(double number)
    {
        double squaredNumber = number * number;
        return squaredNumber;
    }
    static void DisplayResult(string name, double number)
    {
        Console.WriteLine($"{name}, your number squared is {number}!");
    }
}
