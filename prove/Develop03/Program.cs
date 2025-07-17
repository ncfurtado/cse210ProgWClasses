using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture selectedScripture = Menu(); // Get user's choice
        
        // Run the memorization program with selected scripture
        while (true)
        {
            Console.Clear();
            
            // Display reference and scripture
            selectedScripture.DisplayScripture();
            
            // Check if all words are now hidden
            if (selectedScripture.IsCompletelyInvisible())
            {
                Console.Clear();
                selectedScripture.DisplayScripture();
                Console.WriteLine("\nCongratulations! All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
            
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                break;
            }
            
            // Hide more words
            selectedScripture.HideRandomWords();
        }
    }
    
    static Scripture Menu() // Made static and fixed return type
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6");
        Console.WriteLine("3. Create your own scripture");
        Console.Write("Enter your choice (1-3): ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                return new Scripture("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
                                   new Reference("John", "3", "16"));
            
            case "2":
                return new Scripture("Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
                                   new Reference("Proverbs", "3", "5-6"));
            
            case "3":
                return CreateCustomScripture();
            
            default:
                Console.WriteLine("Invalid choice. Defaulting to John 3:16.");
                return new Scripture("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
                                   new Reference("John", "3", "16"));
        }
    }
    
    static Scripture CreateCustomScripture()
    {
        Console.Write("Enter the book name: ");
        string book = Console.ReadLine();
        
        Console.Write("Enter the chapter: ");
        string chapter = Console.ReadLine();
        
        Console.Write("Enter the verse (or verse range like '5-6'): ");
        string verse = Console.ReadLine();
        
        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine();
        
        return new Scripture(text, new Reference(book, chapter, verse));
    }
}