public class ChecklistGoal : Goal
{
    public bool _IsComplete;
    public int _bonusPoints;
    public int _iteration;
    public int _currentIteration;
    public bool _isCompleted;


    public ChecklistGoal(string name, string description, int points, int bonusPoints, int iteration, int currentIteration, bool isCompleted) : base(name, description, points)
    {
        _name = name;
        _description = description;
        _points = points;
        _bonusPoints = bonusPoints;
        _iteration = iteration;
        _currentIteration = currentIteration;
        _isCompleted = isCompleted;

    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public int GetIteration ()
    {
        return _iteration;
    }
    public int GetCurrentIteration()
    {
        return _currentIteration;
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