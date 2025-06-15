using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        Resume myResume = new Resume();

        Console.Write("What is your name? ");
        myResume._name = Console.ReadLine();

        bool again = true;
        while (again)
        {

            Job newJob = new Job();
            Console.Write("What was your job title? ");
            newJob._jobTitle = Console.ReadLine();

            Console.Write("What was the company name? ");
            newJob._company = Console.ReadLine();

            Console.Write("What was your start year? ");
            string startYearInput = Console.ReadLine();
            newJob._startYear = int.Parse(startYearInput);

            Console.Write("What was your end year? ");
            string endYearInput = Console.ReadLine();
            newJob._endYear = int.Parse(endYearInput);

            // Add the job to the resume INSIDE the loop
            myResume._jobs.Add(newJob);

            Console.Write("Would you like to add another job? (yes/no): ");
            string response = Console.ReadLine();
            if (response.ToLower() == "no")
            {
                again = false;
            }
        }

        // Display the resume after all jobs have been added
        Console.WriteLine("\n=== Resume ===");
        myResume.DisplayResume();
    }
}

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void DisplayJobDetails()
    {   
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
