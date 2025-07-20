public abstract class Assignment
{

    protected string _assignmentId;
    protected string AssignmentId { get { return _assignmentId; } set { _assignmentId = value; } }
    protected string _title;
    protected string Title { get { return _title; } set { _title = value; } }
    protected string _description;
    protected string Description { get { return _description; } set { _description = value; } }
    protected DateTime _dueDate;
    protected DateTime DueDate { get { return _dueDate; } set { _dueDate = value; } }
    protected Priority _priority;
    protected Priority Priority { get { return _priority; } set { _priority = value; } }
    protected AssignmentStatus _status;
    protected AssignmentStatus Status { get { return _status; } set { _status = value; } }
    protected double _estimatedHours;
    protected double EstimatedHours { get { return _estimatedHours; } set { _estimatedHours = value; } }
    protected double _actualHours;
    protected double ActualHours { get { return _actualHours; } set { _actualHours = value; } }
    protected string _courseId;
    protected string CourseId { get { return _courseId; } set { _courseId = value; } }
    protected DateTime _dateCreated;
    protected DateTime DateCreated { get { return _dateCreated; } set { _dateCreated = value; } }
    protected DateTime _lastModified;
    protected DateTime LastModified { get { return _lastModified; } set { _lastModified = value; } }

    public Assignment(string id, string title, DateTime dueDate, Course course)
    {
        AssignmentId = id;
        Title = title;
        DueDate = dueDate;
        CourseId = course.GetCourseId();
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


    public string GetCourseId()
    {
        return _courseId;
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

    public void SetLastModified(DateTime lastModified)
    {
        LastModified = lastModified;
    }

    public virtual double CalculateEstimatedTime()
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


    public virtual Assignment Clone()
    {
        return (Assignment)this.MemberwiseClone();
    }
    public virtual string PrintStringData()
    {
        // Prints alli data for the assignmentr in comma separated format in onet line for easy loading
        return $"{GetAssignmentId()},{GetTitle()},{GetDueDate().ToShortDateString()},{GetCourseId()},{GetEstimatedHours()},{GetActualHours()},{GetPriority()},{GetStatus()}";
    }


}