using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        DateModifier dateModifier = new DateModifier();
        dateModifier.CalculateDifference(Console.ReadLine(), Console.ReadLine());
        Console.WriteLine(dateModifier.DifferenceInDays);
    }
}

public class DateModifier
{
    private int differenceInDays;

    public int DifferenceInDays
    {
        get
        {
            return this.differenceInDays;
        }
        set
        {
            this.differenceInDays = value;
        }
    }

    public int CalculateDifference(string firstDate, string secondDate)
    {
        if (DateTime.TryParseExact(firstDate, "yyyy MM dd", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime date1))
        {
            if (DateTime.TryParse(secondDate, out DateTime date2))
            {
                TimeSpan difference = date1 - date2;
                this.DifferenceInDays = Math.Abs(difference.Days);
                return this.DifferenceInDays;
            }
        }

        return 0;
    }
}

