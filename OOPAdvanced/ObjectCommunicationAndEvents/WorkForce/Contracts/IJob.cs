using System;

public interface IJob
{
    string Name { get; }

    int HoursOfWorkRequired { get; }

    bool IsJobDone { get; }

    event EventHandler JobDone;

    void Update();
}