using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekDay);
        this.Notes = notes;
    }

    public WeekDay WeekDay => this.weekDay;

    public string Notes { get; private set; }

    public override string ToString() => $"{this.WeekDay} - {this.Notes}";

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        int weekDayComparison = this.WeekDay.CompareTo(other.WeekDay);
        if (weekDayComparison != 0)
        {
            return weekDayComparison;
        }

        int noteComparison = string.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
        return noteComparison;
    }
}