using System;

public class Job : IJob
{
    private string name;
    private int hoursOfWorkRequired;
    private IEmployee employee;
    private bool isJobDone;

    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        this.Name = name;
        this.HoursOfWorkRequired = hoursOfWorkRequired;
        this.employee = employee;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int HoursOfWorkRequired
    {
        get => this.hoursOfWorkRequired;
        set => this.hoursOfWorkRequired = value;
    }

    public bool IsJobDone => this.isJobDone;

    public event EventHandler JobDone;

    public void Update()
    {
        this.HoursOfWorkRequired -= this.employee.WorkHoursPerWeek;

        if (this.HoursOfWorkRequired <= 0)
        {
            this.isJobDone = true;
            this?.JobDone(this, EventArgs.Empty);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
    }
}