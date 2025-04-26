using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.WriteLine("What is your grade percentage?");
        string grade = Console.ReadLine();
        int gradeNumber = int.Parse(grade);
        string letter = "Z";

        if (gradeNumber >= 90)
        {
            letter = "A";
        }
        else if (gradeNumber >= 80)
        {
             letter = "B";
        }
        else if (gradeNumber >= 80)
        {
             letter = "C";
        }
        else if (gradeNumber >= 70)
        {
             letter = "D";
        }
        else if (gradeNumber < 60)
        {
             letter = "F";
        }

        Console.WriteLine($"{letter}");
        if (gradeNumber >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You did not pass, sorry!");
        }
    }
}