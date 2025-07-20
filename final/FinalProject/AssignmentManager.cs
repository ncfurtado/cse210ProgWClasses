public class AssignmentManager
{
    public AssignmentManager(List<Course> courses, List<Assignment> assignments)
    {
        Courses = courses;
        Assignments = assignments;
    }
    
    public List<Course> Courses { get; set; }
    public List<Assignment> Assignments { get; set; }
    
    public List<Course> GetAllCourses()
    {
        return Courses; // Fixed: Return actual courses instead of empty list
    }
    
    public List<Assignment> GetAllAssignments()
    {
        return Assignments; // Fixed: Return actual assignments instead of empty list
    }
    
    public void RemoveCourse(string courseId)
    {
        var courseToRemove = Courses.FirstOrDefault(c => c.GetCourseId() == courseId);
        if (courseToRemove != null)
        {
            Courses.Remove(courseToRemove);
            // Remove all assignments associated with this course
            Assignments.RemoveAll(a => a.GetCourseId() == courseId);
            Console.WriteLine($"Course with ID {courseId} has been removed.");
        }
    }
    
    public Course GetCourse(string courseId)
    {
        return Courses.FirstOrDefault(c => c.GetCourseId() == courseId);
    }
    
    public bool RemoveAssignment(string assignmentId)
    {
        var assignmentToRemove = Assignments.FirstOrDefault(a => a.GetAssignmentId() == assignmentId);
        if (assignmentToRemove != null)
        {
            Assignments.Remove(assignmentToRemove);
            return true;
        }
        return false;
    }
    
    public Assignment GetAssignment(string assignmentId)
    {
        return Assignments.FirstOrDefault(a => a.GetAssignmentId() == assignmentId);
    }
    
    public List<Assignment> GetAssignmentsByCourse(string courseId)
    {
        return Assignments.Where(a => a.GetCourseId() == courseId).ToList();
    }
    
    public List<Assignment> GetOverdueAssignments(List<Assignment> assignments)
    {
        return Assignments.Where(a => a.GetDueDate() < DateTime.Now && a.GetStatus() != AssignmentStatus.COMPLETED).ToList();
    }
    
    public List<Assignment> GetUpcomingAssignments(int days)
    {
        DateTime cutoffDate = DateTime.Now.AddDays(days);
        return Assignments.Where(a => a.GetDueDate() >= DateTime.Now && a.GetDueDate() <= cutoffDate).ToList();
    }
    
    public List<Assignment> GetAssignmentsByDueDate(DateTime dueDate)
    {
        return Assignments.Where(a => a.GetDueDate().Date == dueDate.Date).ToList();
    }
    
    public void LoadAssignmentsFromFile(string filename)
    {
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                // Code to parse the line and create Assignment objects
                // Add the created Assignment objects to the list of assignments
            }
        }
    }
    
    public string GenerateAssignmentId()
    {
        return Guid.NewGuid().ToString();
    }
}