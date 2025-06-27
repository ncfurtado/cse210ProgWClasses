public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;


    public virtual int RecordEvent()
    {
        return _points;
    }


    public virtual void IsComplete()
     {
        // _isCompleted = true;
    }


    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }


    public string GetName()
    {
        return _name;
    }


    public string GetDescription()
    {
        return _description;
    }


    public int GetPoints()
    {
        return _points;
}

    public void SaveGoal()
    {

    }


    public string LoadGoal()
    {
        return _name;
    }

}