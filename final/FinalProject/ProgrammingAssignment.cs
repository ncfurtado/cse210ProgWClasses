class ProgrammingAssignment : Assignment
{
    public string _programmingLanguage;
    public string ProgrammingLanguage { get { return _programmingLanguage; } set { _programmingLanguage = value; } }
    public string _repository;
    public string Repository { get { return _repository; } set { _repository = value; } }


    public ProgrammingAssignment() : base(string.Empty, string.Empty, DateTime.Now, null)
    {
        // Default constructor
    }
    public ProgrammingAssignment(string id, string title, DateTime dueDate, Course course, string language, string repository)
        : base(id, title, dueDate, course)
    {
        ProgrammingLanguage = language;
        Repository = repository;
    }

    public string GetLanguage()
    {
        return ProgrammingLanguage;
    }

    public void SetLanguage(string language)
    {
        ProgrammingLanguage = language;
    }

    public string GetRepository()
    {
        return Repository;
    }

    public void SetRepository(string repository)
    {
        Repository = repository;
    }

    public override double CalculateEstimatedTime()
    {
        // Custom logic for programming assignments
        return GetEstimatedHours() * 1.5; // Example: increase estimated time by 50%
    }
    public override string PrintStringData()
    {
        // Prints all data for the programming assignment in comma separated format in one line for easy loading
        return $"ProgrammingAssignment:{GetAssignmentId()},{GetTitle()},{GetDueDate().ToShortDateString()},{GetCourseId()},{ProgrammingLanguage},{Repository},{GetEstimatedHours()},{GetActualHours()},{GetPriority()},{GetStatus()}";
    }
}
//     public override Assignment Clone()
//     {
//         return new ProgrammingAssignment(AssignmentId, Title, DueDate, Course, ProgrammingLanguage)
//         {
//             Description = this.Description,
//             Priority = this.Priority,
//             Status = this.Status,
//             EstimatedHours = this.EstimatedHours,
//             ActualHours = this.ActualHours,
//             DateCreated = this.DateCreated,
//             LastModified = this.LastModified,
//             Repository = this.Repository
//         };
//     }
// }
