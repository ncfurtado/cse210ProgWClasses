using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int number = -1;
        double sum = 0;
        int largest = 0;
        List<int> numbers = new List<int>();

        while (number != 0)
        {
            Console.Write("Enter Number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            if (number != 0)
            {
            numbers.Add(number);
            }

        }
        foreach (int value in numbers)
        {
            sum += value;
            if (value > largest)
            {
                largest = value;
            }
        }

        double average = sum / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}