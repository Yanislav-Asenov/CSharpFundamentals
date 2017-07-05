using System;
using System.Text;

public class Worker : Human
{
    private decimal salary;
    private decimal workingHoursPerDay;

    public Worker(string firstName, string lastName, decimal salary, decimal workingHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = salary;
        this.WorkingHoursPerDay = workingHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return this.salary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.salary = value;
        }
    }

    public decimal WorkingHoursPerDay
    {
        get { return this.workingHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workingHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToString());
        sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        sb.AppendLine($"Hours per day: {this.WorkingHoursPerDay:F2}");

        decimal salaryPerHour = this.WeekSalary / (this.WorkingHoursPerDay * 5);
        sb.Append($"Salary per hour: {salaryPerHour:F2}");
        return sb.ToString();
    }
}

