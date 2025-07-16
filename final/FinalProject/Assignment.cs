abstract class Assignment
{

    protected string _assignmentId;
    protected string _title;
    protected string _description;
    protected DateTime _dueDate;
    protected  Priority _priority;
    protected  AssignmentStatus _status;
    protected double _estimatedHours;
    protected double _actualHours;
    protected Course _course;
    protected DateTime _dateCreated;
    protected DateTime _lastModified;

    public Assignment(string id, string title, DateTime dueDate, Course course)
    {
        _assignmentId = id;
        _title = title;
        _dueDate = dueDate;
        _course = course;
        _priority = Priority.Normal;
        _status = AssignmentStatus;
        _estimatedHours = 0.0
        _actualHours = 0.0
        _dateCreated = DateTime.Now
        _lastModified = DateTime.Now
        }
    public string GetAssignmentId()
    {

    }


    public string GetTitle()
    {
        return _title;
    }


    public void SetTitle(string title)
    {
        _title = title;
    }


    public string GetDescription()
    {
        return _description;
    }


    public void SetDescription(string description)
    {
        _description = description;
    }


    public DateTime GetDueDate()
    {
        return _dueDate;
    }


    public void SetDueDate(DateTime dueDate)
    {
        _dueDate = dueDate;
    }


    public Priority GetPriority()
    {
        return _priority;
    }


    public void SetPriority(Priority priority)
    {
        _priority = priority;
    }


    public AssignmentStatus GetStatus()
    {
        return _status;
    }


    public void SetStatus(AssignmentStatus status)
    {
        _status = status;
    }


    public Course GetCourse()
    {
        return _course;
    }


    public double GetEstimatedHours()
    {
        return _estimatedHours;
    }


    public void SetEstimatedHours(double hours)
    {
        _estimatedHours = hours;
    }


    public double GetActualHours()
    {
        return _actualHours;
    }


    public void AddActualHours(double hours)
    {
        _actualHours += hours;
    }


    public int GetDaysUntilDue()
    {
        return (int)(_dueDate - DateTime.Now).TotalDays;
    }


    public bool IsOverdue()
    {
        return DateTime.Now > _dueDate && _status != AssignmentStatus.Completed;
    }


    public bool IsComplete()
    {
        return _status == AssignmentStatus.Completed;
    }


    public double CalculateEstimatedTime()
    {
        return _estimatedHours;
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


    public string ToString()
    {
        return $"{_title} (Due: {_dueDate})";
    }


    public bool Equals(Assignment other)
    {
        if (other == null) return false;
        return _assignmentId == other._assignmentId;
    }