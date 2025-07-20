public class GroupAssignment : Assignment
{
    private List<string> _groupMembers;
    public List<string> GroupMembers { get { return _groupMembers; } set { _groupMembers = value; } }
    private string _groupLeader;
    public string GroupLeader { get { return _groupLeader; } set { _groupLeader = value; } }
    private int _groupSize;
    public int GroupSize { get { return _groupSize; } set { _groupSize = value; } }
    private string _meetingSchedule;
    public string MeetingSchedule { get { return _meetingSchedule; } set { _meetingSchedule = value; } }
    private Dictionary<string, List<string>> _individualTasks;
    private string _collaborationPlatform;
    private string CollaborationPlatform { get { return _collaborationPlatform; } set { _collaborationPlatform = value; } }
    private bool _presentationRequired;
    private bool PresentationRequired { get { return _presentationRequired; } set { _presentationRequired = value; } }

    public GroupAssignment(string id, string title, DateTime dueDate, Course course, List<string> groupMembers, string groupLeader, int groupSize, string collaborationPlatform, bool presentationRequired) : base(id, title, dueDate, course)
    {
        _groupMembers = groupMembers;
        _groupLeader = groupLeader;
        _groupSize = groupSize;
        _meetingSchedule = string.Empty; // Default to empty meeting schedule
        _individualTasks = new Dictionary<string, List<string>>();
        _collaborationPlatform = collaborationPlatform;
        _presentationRequired = presentationRequired;
        _groupMembers = new List<string>();
        _meetingSchedule = string.Empty;
        _individualTasks = new Dictionary<string, List<string>>();
        _collaborationPlatform = string.Empty;
        _presentationRequired = false;
    }
    public GroupAssignment(string id, string title, DateTime dueDate, Course course): base (id, title, dueDate, course)
    {
        GroupMembers = new List<string>();
    }

    public override double CalculateEstimatedTime()
    {
        // Assuming group assignments take less time per person
        return EstimatedHours / GroupMembers.Count;
    }
    public override string PrintStringData()
    {
        // Prints all data for the group assignment in comma separated format in one line for easy loading
        return $"GroupAssignment:{GetAssignmentId()},{GetTitle()},{GetDueDate().ToShortDateString()},{GetCourseId()},{string.Join(";", GroupMembers)},{GroupLeader},{GroupSize},{MeetingSchedule},{CollaborationPlatform},{PresentationRequired},{GetEstimatedHours()},{GetActualHours()},{GetPriority()},{GetStatus()}";
    }

    public override Assignment Clone()
    {
        GroupAssignment clone = (GroupAssignment)this.MemberwiseClone();
        clone.GroupMembers = new List<string>(this.GroupMembers);
        return clone;
    }
}