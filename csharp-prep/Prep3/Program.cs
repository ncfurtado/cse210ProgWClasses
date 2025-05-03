using System;
using System.Runtime.CompilerServices;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");   
        Random randomGenerator = new Random();
        int maxValue = 11;
        int magicNumber = randomGenerator.Next(1, maxValue);
        int guesses = 0;
        Console.WriteLine($"Welcome to the Magic Number Game! Guess the number (range is 1 - {maxValue})");  

        bool correct = false;
        bool again = true;

        while (again != false)
        {
            while (correct == false)
            {
                Console.Write("What is the your guess? ");
                string input = Console.ReadLine();    
                int guess = int.Parse(input);
                guesses ++;
                if (guess > magicNumber)
                {
                    Console.WriteLine("Too high!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Too low!");
                }
                
                else if (guess == magicNumber)
                {
                    Console.WriteLine($"You guessed it! The number was {magicNumber}. ");
                    Console.WriteLine($"You guessed {guesses} times! ");
                    correct = true;
                }
                else if (guess > maxValue)
                {
                    Console.WriteLine("That is way too high!!");
                }
            }
            Console.WriteLine("Would you like to play again? ");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                again = true;
            }
            if (response.ToLower() == "no")
            {
                again = false;
            }
        }

    }
}