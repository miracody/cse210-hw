using System;

public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) -- Recorded {_timesRecorded} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesRecorded}";
    }

    // Optional: restore state when loading from file
    public void SetTimesRecorded(int times)
    {
        _timesRecorded = times;
    }
}
