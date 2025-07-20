public class Course
{
    private string _courseId;
    private string _courseName;
    private string _instructor;
    private int _creditHours;
    private string _semester;
    public string CourseId { get { return _courseId; } set { _courseId = value; } }
    public string CourseName { get { return _courseName; } set { _courseName = value; } }
    public string Instructor { get { return _instructor; } set { _instructor = value; } }
    public int CreditHours { get { return _creditHours; } set { _creditHours = value; } }
    public string Semester { get { return _semester; } set { _semester = value; } }
    public List<Assignment> Assignments { get; set; }

    public Course(string id, string name, string instructor, int creditHours, string semester)
    {
        _courseId = id;
        _courseName = name;
        _instructor = instructor;
        _creditHours = creditHours;
        _semester = semester;
        Assignments = new List<Assignment>();
    }


    public string GetCourseId()
    {
        return CourseId;
    }
    public void SetCourseId(string id)
    {
        CourseId = id;
    }
    public string GetCourseName()
    {
        return CourseName;
    }
    public void SetCourseName(string name)
    {
        CourseName = name;
    }
    public string GetInstructor()
    {
        return Instructor;
    }
    public void SetInstructor(string instructor)
    {
        Instructor = instructor;
    }
    public int GetCreditHours()
    {
        return CreditHours;
    }
    public void SetCreditHours(int hours)
    {
        CreditHours = hours;
    }
    public void AddAssignment(Assignment assignment)
    {
        Assignments.Add(assignment);
    }
    public bool RemoveAssignment(string assignmentId)
    {
        var assignment = Assignments.FirstOrDefault(a => a.GetAssignmentId() == assignmentId);
        if (assignment != null)
        {
            Assignments.Remove(assignment);
            return true;
        }
        return false;
    }
    public List<Assignment> GetAssignments()
    {
        return Assignments;
    }
    public int GetAssignmentCount()
    {
        return Assignments.Count;
    }
    // public double GetAverageGrade()
    // {
    //     if (Assignments.Count == 0) return 0;

    //     double total = Assignments.Sum(a => a.GetGrade());
    //     return total / Assignments.Count;
    // }
    public string PrintStringData()
    {
        return $"Course:{CourseId},{CourseName},{Instructor},{CreditHours},{Semester}";
    }
}
