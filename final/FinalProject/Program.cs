using System;
using System.IO;

using System.Collections.Generic;
using System.Text.RegularExpressions;

partial class Program
{
    static void Main(string[] args)
    {
        int menuChoice = -1;

        Console.WriteLine("Hello FinalProject World!");
        Console.WriteLine("Welcome to the Weekly Assignment Tracker!");
        List<Assignment> myAssignments = new List<Assignment>();
        List<Course> myCourses = new List<Course>();
        AssignmentManager theAssignmentManager = new AssignmentManager(myCourses, myAssignments);

        while (menuChoice != 10)
        {
            DisplayMainMenu();
            Console.Write("Select a choice from the menu: ");
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {

                case 1: // View Assignments
                    Console.WriteLine("How would you like to view your assignments?");
                    Console.WriteLine("1. View All Assignments");
                    Console.WriteLine("2. View Assignments by Course");
                    Console.WriteLine("3. View Assignments by Due Date");
                    Console.WriteLine("4. View Upcoming Assignments");
                    Console.WriteLine("5. View Overdue Assignments");
                    Console.Write("Please enter the number of your choice: ");
                    int viewChoice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (viewChoice)
                    {
                        case 1: // View All Assignments
                            Console.Clear();
                            Console.WriteLine("=== All Assignments ===");
                            foreach (Assignment assignment in myAssignments)
                            {
                                Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()}) {assignment.GetStatus()}");
                            }
                            break;

                        case 2: // View Assignments by Course
                            Console.Clear();
                            Console.WriteLine("=== Assignments by Course ===");
                            Console.Write("Enter the course ID: ");
                            string courseId = Console.ReadLine();
                            List<Assignment> courseAssignments = theAssignmentManager.GetAssignmentsByCourse(courseId);
                            foreach (Assignment assignment in courseAssignments)
                            {
                                Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()})");
                            }
                            break;

                        case 3: // View Assignments by Due Date
                            Console.Clear();
                            Console.WriteLine("=== Assignments by Due Date ===");
                            Console.Write("Enter the due date (yyyy-mm-dd): ");
                            DateTime dueDate = DateTime.Parse(Console.ReadLine());
                            List<Assignment> dateAssignments = theAssignmentManager.GetAssignmentsByDueDate(dueDate);
                            foreach (Assignment assignment in dateAssignments)
                            {
                                Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()})");
                            }
                            break;

                        case 4: // View Upcoming Assignments
                            Console.Clear();
                            Console.WriteLine("=== Upcoming Assignments ===");
                            List<Assignment> upcomingAssignments1 = theAssignmentManager.GetUpcomingAssignments(7);
                            foreach (Assignment assignment in upcomingAssignments1)
                            {
                                Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()})");
                            }
                            break;

                        case 5: // View Overdue Assignments
                            Console.Clear();
                            Console.WriteLine("=== Overdue Assignments ===");
                            List<Assignment> overdueAssignments1 = theAssignmentManager.GetOverdueAssignments(myAssignments);
                            foreach (Assignment assignment in overdueAssignments1)
                            {
                                Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()})");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    Console.WriteLine();
                    break;

                case 2: // Add New Assignment
                    Console.Clear();
                    if (myCourses.Count == 0)
                    {
                        Console.WriteLine("No courses available. Please add a course first.");
                        break;
                    }
                    Console.WriteLine("=== Add New Assignment ===");
                    // Code to add a new assignment
                    Console.WriteLine("Which current course would you like to add an assignment to?");
                    Console.WriteLine("Here are your current courses:");
                    foreach (Course course in myCourses)
                    {
                        Console.WriteLine($"- {course.GetCourseId()} : {course.GetCourseName()}");
                    }
                    Console.WriteLine($"Please enter the course ID to add an assignment to: ");
                    string courseIdInput = Console.ReadLine();
                    Course selectedCourse = myCourses.FirstOrDefault(c => c.GetCourseId() == courseIdInput);
                    if (selectedCourse == null)
                    {
                        Console.WriteLine("Course not found. Please try again.");
                        break;
                    }
                    Console.Write("What kind of assignment would you like to add? \n 1. Programming Assignment \n 2. Group Assignment \n Please enter the number of your choice: ");
                    string assignmentType = Console.ReadLine();

                    if (assignmentType == "1")
                    {
                        // Add Programming Assignment
                        // Console.Write("Enter which course this assignment is for: ");
                        // string course1 = Console.ReadLine();
                        Console.Write("Enter the title of the programming assignment: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter the due date (yyyy-mm-dd): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter the programming language: ");
                        string language = Console.ReadLine();
                        Console.Write("Do you want to add a repository link? (yes/no): ");
                        string addRepository = Console.ReadLine();

                        string repository = string.Empty;
                        if (addRepository.Equals("yes", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter the repository URL: ");
                            repository = Console.ReadLine();
                        }
                        // create a  simple random assignment 
                        string assignmentIdTemp = Guid.NewGuid().ToString();
                        ProgrammingAssignment programmingAssignment = new ProgrammingAssignment(assignmentIdTemp, title, dueDate, selectedCourse, language, repository);
                        myAssignments.Add(programmingAssignment);
                    }
                    else if (assignmentType == "2")
                    {
                        // Add Group Assignment
                        Console.Write("Enter the title of the group assignment: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter the due date (yyyy-mm-dd): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter the group members (comma-separated): ");
                        string[] groupMembers = Console.ReadLine().Split(',');
                        Console.Write("Enter the group leader: ");
                        string groupLeader = Console.ReadLine();
                        Console.Write("Enter the collaboration platform: ");
                        string collaborationPlatform = Console.ReadLine();
                        Console.WriteLine("is there a presentation required? (yes/no)");
                        string presentationInput = Console.ReadLine();

                        bool presentationRequired = presentationInput.Equals("yes", StringComparison.OrdinalIgnoreCase);
                        // create a random group ID
                        string groupId = Guid.NewGuid().ToString();

                        GroupAssignment groupAssignment = new GroupAssignment(groupId, title, dueDate, selectedCourse, new List<string>(groupMembers), groupLeader, groupMembers.Length, collaborationPlatform, presentationRequired);
                        myAssignments.Add(groupAssignment);

                    }
                    break;

                case 3: // Mark Assignment Complete
                    Console.Clear();
                    Console.WriteLine("=== Mark Assignment Complete ===");
                    if (myAssignments.Count == 0)
                    {
                        Console.WriteLine("No assignments available to mark as complete.");
                        break;
                    }
                    Console.WriteLine("Here are your current assignments:");
                    foreach (Assignment assignment in myAssignments)
                    {
                        Console.WriteLine($"- {assignment.GetAssignmentId()} {assignment.GetTitle()} (Due: {assignment.GetDueDate()}) - Status: {assignment.GetStatus()}");
                    }
                    Console.Write("Enter the assignment ID to mark as complete: ");
                    string assignmentId = Console.ReadLine();
                    Assignment assignmentToComplete = myAssignments.FirstOrDefault(a => a.GetAssignmentId() == assignmentId);
                    if (assignmentToComplete == null)
                    {
                        Console.WriteLine("Assignment not found.");
                        break;
                    }
                    // confirm selected assignment
                    Console.WriteLine($"You have selected: {assignmentToComplete.GetTitle()} (Due: {assignmentToComplete.GetDueDate()})");
                    Console.WriteLine("Are you sure you want to mark this assignment as complete? (yes/no)");
                    string confirmation = Console.ReadLine();
                    if (confirmation.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        assignmentToComplete.SetStatus(AssignmentStatus.COMPLETED);
                        assignmentToComplete.SetLastModified(DateTime.Now);
                        // Code to mark an assignment as complete
                    }
                    else
                    {
                        Console.WriteLine("Operation cancelled.");
                    }
                    break;

                case 4: // View Upcoming Assignments
                    Console.Clear();
                    Console.WriteLine("=== View Upcoming Assignments ===");
                    Console.Write("Enter the number of days to check for upcoming assignments: ");
                    int days = int.Parse(Console.ReadLine());
                    List<Assignment> upcomingAssignments = theAssignmentManager.GetUpcomingAssignments(days);
                    foreach (Assignment assignment in upcomingAssignments)
                    {
                        Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()})");
                    }
                    break;

                case 5: // View Overdue Assignments
                    Console.Clear();
                    Console.WriteLine("=== View Overdue Assignments ===");
                    List<Assignment> overdueAssignments = theAssignmentManager.GetOverdueAssignments(myAssignments);
                    if (overdueAssignments.Count == 0)
                    {
                        Console.WriteLine("No overdue assignments found.");
                    }
                    else
                    {
                        foreach (Assignment assignment in overdueAssignments)
                        {
                            Console.WriteLine($"- {assignment.GetTitle()} (Due: {assignment.GetDueDate()})");
                        }
                    }
                    // Code to view overdue assignments
                    break;

                case 6: // Manage Courses
                    Console.Clear();
                    Console.WriteLine("=== Manage Courses ===");
                    Console.WriteLine("1. View All Courses");
                    Console.WriteLine("2. Add New Course");
                    Console.WriteLine("3. Edit Course");
                    Console.WriteLine("4. Remove Course");
                    Console.WriteLine("5. Back to Main Menu");
                    Console.Write("Select an option: ");
                    int courseChoice = int.Parse(Console.ReadLine());

                    while (courseChoice < 1 || courseChoice > 5)
                    {
                        Console.WriteLine("Invalid choice. Please select a valid option (1-5).");
                        Console.Write("Select an option: ");
                        courseChoice = int.Parse(Console.ReadLine());
                    }

                    switch (courseChoice)
                    {
                        case 1: // View All Courses
                            Console.Clear();
                            Console.WriteLine("=== View All Courses ===");
                            foreach (Course theCourse in myCourses)
                            {
                                Console.WriteLine($"- {theCourse.GetCourseId()} : {theCourse.GetCourseName()} from {theCourse.GetInstructor()} ({theCourse.GetCreditHours()} credit hours) - {theCourse.Semester}");
                            }
                            break;

                        case 2: // Add New Course
                            Console.Clear();
                            Console.WriteLine("=== Add New Course ===");
                            Console.Write("Enter Course ID: ");
                            string newCourseId = Console.ReadLine();
                            Console.Write("Enter Course Name: ");
                            string newCourseName = Console.ReadLine();
                            Console.Write("Enter Instructor Name: ");
                            string instructorName = Console.ReadLine();
                            Console.Write("Enter Credit Hours: ");
                            int creditHours = int.Parse(Console.ReadLine());
                            Console.Write("Enter Semester: ");
                            string semester = Console.ReadLine();
                            Course newCourse = new Course(newCourseId, newCourseName, instructorName, creditHours, semester);
                            myCourses.Add(newCourse);
                            Console.WriteLine("Course added successfully!");
                            break;

                        case 3: // Edit Course
                            Console.Clear();
                            Console.WriteLine("=== Edit Course ===");
                            // Display existing courses
                            foreach (Course course in myCourses)
                            {
                                Console.WriteLine($"- {course.GetCourseId()} : {course.GetCourseName()}");
                            }
                            Console.Write("Enter Course ID to edit: ");
                            string editCourseId = Console.ReadLine();
                            Course courseToEdit = myCourses.FirstOrDefault(c => c.GetCourseId() == editCourseId);
                            if (courseToEdit == null)
                            {
                                Console.WriteLine("Course not found.");
                                break;
                            }
                            break;

                        case 4: // Remove Course
                            Console.Clear();
                            Console.WriteLine("=== Remove Course ===");
                            // Display existing courses
                            foreach (Course course in myCourses)
                            {
                                Console.WriteLine($"- {course.GetCourseId()} : {course.GetCourseName()}");
                            }
                            Console.Write("Enter Course ID to remove: ");
                            string removeCourseId = Console.ReadLine();
                            Course courseToRemove = myCourses.FirstOrDefault(c => c.GetCourseId() == removeCourseId);
                            if (courseToRemove == null)
                            {
                                Console.WriteLine("Course not found.");
                                break;
                            }
                            myCourses.Remove(courseToRemove);
                            // Optionally, remove all assignments associated with this course
                            myAssignments.RemoveAll(a => a.GetCourseId() == courseToRemove.GetCourseId());
                            Console.WriteLine("Course removed successfully!");
                            break;

                        case 5: // Back to Main Menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                    break;

                case 7: // View Calendar
                    Console.Clear();
                    Console.WriteLine("=== View Calendar ===");

                    // Display a simple calendar view
                    DateTime today = DateTime.Now;
                    Console.WriteLine($"Calendar for {today.ToString("MMMM yyyy")}");
                    Console.WriteLine("Su Mo Tu We Th Fr Sa");
                    int firstDayOfMonth = (int)new DateTime(today.Year, today.Month, 1).DayOfWeek;
                    for (int i = 0; i < firstDayOfMonth; i++)
                    {
                        Console.Write("   "); // Print empty spaces for days before the first day of the month
                    }
                    break;

                case 8: // View Progress Report
                    Console.Clear();
                    Console.WriteLine("=== View Progress Report ===");

                    // Show percentage of assignments completed per course
                    foreach (Course course in myCourses)
                    {
                        List<Assignment> courseAssignments = course.GetAssignments();
                        int totalAssignments = courseAssignments.Count;
                        int completedAssignments = courseAssignments.Count(a => a.GetStatus() == AssignmentStatus.COMPLETED);
                        double completionPercentage = totalAssignments > 0 ? (double)completedAssignments / totalAssignments * 100 : 0;
                        Console.WriteLine($"Course: {course.GetCourseName()} - Completion: {completionPercentage:F2}%");
                    }
                    break;

                case 9: // Manage Data
                    Console.Clear();
                    Console.WriteLine("=== Manage Data ===");
                    Console.WriteLine("1. Save Data to File");
                    Console.WriteLine("2. Load Data from File");
                    Console.WriteLine("3. Back to Main Menu");
                    Console.Write("Select an option: ");
                    int dataChoice = int.Parse(Console.ReadLine());
                    while (dataChoice < 1 || dataChoice > 3)
                    {
                        Console.Write("Select an option: ");
                        dataChoice = int.Parse(Console.ReadLine());
                    }
                    switch (dataChoice)
                    {
                        case 1: // Save Data
                            Console.Clear();
                            Console.WriteLine("=== Save Data ===");

                            // Debug: Check what data exists
                            var courses = theAssignmentManager.GetAllCourses();
                            var assignments = theAssignmentManager.GetAllAssignments();

                            Console.WriteLine($"Number of courses: {courses.Count}");
                            Console.WriteLine($"Number of assignments: {assignments.Count}");

                            if (courses.Count == 0 && assignments.Count == 0)
                            {
                                Console.WriteLine("No data to save! Add some courses and assignments first.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }

                            Console.Write("Enter the filename to save your data: ");
                            string saveFileName = Console.ReadLine();

                            try
                            {
                                Program.SaveToFile(saveFileName, theAssignmentManager);
                                Console.WriteLine("Data saved successfully!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error saving data: {ex.Message}");
                            }

                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        case 2: // Load Data
                            Console.Write("Enter the filename to load your data: ");
                            string loadFileName = Console.ReadLine();

                            try
                            {
                                Program.LoadFromFile(loadFileName, myCourses, myAssignments);
                                // Recreate the AssignmentManager with the loaded data
                                theAssignmentManager = new AssignmentManager(myCourses, myAssignments);
                                Console.WriteLine("Data loaded successfully!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error loading data: {ex.Message}");
                            }
                            break;
                        case 3: // Back to Main Menu
                            break;
                    }
                    break;

                case 10: // Exit
                    Console.Clear();
                    Console.WriteLine("Exiting the program...");
                    break;
            }
        }
    }

    private static void DisplayMainMenu()
    {
        Console.WriteLine("=== Weekly Assignment Tracker ===");
        Console.WriteLine("1. View Assignments");
        Console.WriteLine("2. Add New Assignment");
        Console.WriteLine("3. Mark Assignment Complete");
        Console.WriteLine("4. View Upcoming Assignments");
        Console.WriteLine("5. View Overdue Assignments");
        Console.WriteLine("6. Manage Courses");
        Console.WriteLine("7. View Calendar");
        Console.WriteLine("8. View Progress Report");
        Console.WriteLine("9. Manage Data");
        Console.WriteLine("10. Exit");
        Console.Write("Select an option: ");
    }

    public static void SaveToFile(string fileName, AssignmentManager assignmentManager)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            var courses = assignmentManager.GetAllCourses();
            var assignments = assignmentManager.GetAllAssignments();

            Console.WriteLine($"About to save {courses.Count} courses and {assignments.Count} assignments");

            foreach (Course course in courses)
            {
                string courseData = course.PrintStringData();
                Console.WriteLine($"Writing course: {courseData}");
                outputFile.WriteLine(courseData);
            }

            foreach (Assignment assignment in assignments)
            {
                string assignmentData = assignment.PrintStringData();
                Console.WriteLine($"Writing assignment: {assignmentData}");
                outputFile.WriteLine(assignmentData);
            }
        }
    }

    public static void LoadFromFile(string filename, List<Course> myCourses, List<Assignment> myAssignments)
{
    using (StreamReader inputFile = new StreamReader(filename))
    {
        string line;
        while ((line = inputFile.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            if (parts.Length > 0)
            {
                if (parts[0].StartsWith("Course:"))
                {
                    string courseId = parts[0].Substring(7);
                    string courseName = parts[1];
                    string instructor = parts[2]; 
                    int creditHours = int.Parse(parts[3]);
                    string semester = parts[4];
                    
                    Course course = new Course(courseId, courseName, instructor, creditHours, semester);
                    myCourses.Add(course); 
                    Console.WriteLine($"Loaded course: {courseId} - {courseName}");
                }
                else if (parts[0].StartsWith("ProgrammingAssignment:"))
                {
                    string assignmentId = parts[0].Substring(21);
                    string title = parts[1];
                    DateTime dueDate = DateTime.Parse(parts[2]);
                    string courseId = parts[3]; 
                    string programmingLanguage = parts[4];
                    string repository = parts[5];
                    
                    Course assignmentCourse = myCourses.FirstOrDefault(c => c.GetCourseId() == courseId);
                    if (assignmentCourse != null)
                    {
                        ProgrammingAssignment assignment = new ProgrammingAssignment(
                            assignmentId, title, dueDate, assignmentCourse, programmingLanguage, repository);
                        myAssignments.Add(assignment);
                        Console.WriteLine($"Loaded programming assignment: {title}");
                    }
                }
                else if (parts[0].StartsWith("GroupAssignment:"))
                {
                    string assignmentId = parts[0].Substring(16);
                    string title = parts[1];
                    DateTime dueDate = DateTime.Parse(parts[2]);
                    string courseId = parts[3];
                    List<string> groupMembers = new List<string>(parts[4].Split(';'));
                    string groupLeader = parts[5];
                    int groupSize = int.Parse(parts[6]);
                    string collaborationPlatform = parts[7];
                    bool presentationRequired = bool.Parse(parts[8]);
                    
                    // Find the course object
                    Course assignmentCourse = myCourses.FirstOrDefault(c => c.GetCourseId() == courseId);
                    if (assignmentCourse != null)
                    {
                        GroupAssignment assignment = new GroupAssignment(
                            assignmentId, title, dueDate, assignmentCourse, groupMembers, 
                            groupLeader, groupSize, collaborationPlatform, presentationRequired);
                        myAssignments.Add(assignment);
                        Console.WriteLine($"Loaded group assignment: {title}");
                    }
                }
            }
        }
    }
    Console.WriteLine($"Loading complete! Loaded {myCourses.Count} courses and {myAssignments.Count} assignments.");
}
}