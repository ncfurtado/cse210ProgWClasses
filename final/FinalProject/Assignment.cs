abstract class Assignment
{

    protected string AssignmentId { get { return AssignmentId; } set { AssignmentId = value; } }
    protected string Title { get { return Title; } set { Title = value; } }
    protected string Description { get { return Description; } set { Description = value; } }
    protected DateTime DueDate { get { return DueDate; } set { DueDate = value; } }
    protected Priority Priority { get { return Priority; } set { Priority = value; } }
    protected AssignmentStatus Status { get { return Status; } set { Status = value; } }
    protected double EstimatedHours { get { return EstimatedHours; } set { EstimatedHours = value; } }
    protected double ActualHours { get { return ActualHours; } set { ActualHours = value; } }
    protected Course Course { get { return Course; } set { Course = value; } }
    protected DateTime DateCreated { get { return DateCreated; } set { DateCreated = value; } }
    protected DateTime LastModified { get { return LastModified; } set { LastModified = value; } }

    public Assignment(string id, string title, DateTime dueDate, Course course)
    {
        AssignmentId = id;
        Title = title;
        DueDate = dueDate;
        Course = course;
        Priority = Priority.NORMAL;
        Status = AssignmentStatus.NOT_STARTED;
        EstimatedHours = 0.0;
        ActualHours = 0.0;
        DateCreated = DateTime.Now;
        LastModified = DateTime.Now;
    }
    public string GetAssignmentId()
    {
        return AssignmentId;
    }


    public string GetTitle()
    {
        return Title;
    }


    public void SetTitle(string title)
    {
        Title = title;
    }


    public string GetDescription()
    {
        return Description;
    }


    public void SetDescription(string description)
    {
        Description = description;
    }


    public DateTime GetDueDate()
    {
        return DueDate;
    }


    public void SetDueDate(DateTime dueDate)
    {
        DueDate = dueDate;
    }


    public Priority GetPriority()
    {
        return Priority;
    }


    public void SetPriority(Priority priority)
    {
        Priority = priority;
    }


    public AssignmentStatus GetStatus()
    {
        return Status;
    }


    public void SetStatus(AssignmentStatus status)
    {
        Status = status;
    }


    public Course GetCourse()
    {
        return Course;
    }


    public double GetEstimatedHours()
    {
        return EstimatedHours;
    }


    public void SetEstimatedHours(double hours)
    {
        EstimatedHours = hours;
    }


    public double GetActualHours()
    {
        return ActualHours;
    }


    public void AddActualHours(double hours)
    {
        ActualHours += hours;
    }


    public int GetDaysUntilDue()
    {
        return (int)(DueDate - DateTime.Now).TotalDays;
    }


    public bool IsOverdue()
    {
        return DateTime.Now > DueDate && Status != AssignmentStatus.COMPLETED;
    }


    public bool IsComplete()
    {
        return Status == AssignmentStatus.COMPLETED;
    }


    public double CalculateEstimatedTime()
    {
        return EstimatedHours;
    }


    public List<string> GetRequiredResources()
    {
        return new List<string>();
    }


    public List<string> GetCompletionCriteria()
    {
        return new List<string>();
    }


    public Assignment Clone()
    {
        return (Assignment)this.MemberwiseClone();
    }


    public override string ToString()
    {
        return $"{Title} (Due: {DueDate})";
    }


    public bool Equals(Assignment other)
    {
        if (other == null) return false;
        return AssignmentId == other.AssignmentId;
    }
}