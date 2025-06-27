public class SimpleGoal : Goal
{
    protected bool _isCompleted;

    public SimpleGoal(string name, string description, int points, bool isCompleted) : base(name, description, points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = isCompleted;
    }

    public bool GetCompletionStatus()
    {
        return _isCompleted;
    }

    public override int RecordEvent()
    {
        return _points;
    }


    public override void IsComplete()
    {
        _isCompleted = true;
    }
}