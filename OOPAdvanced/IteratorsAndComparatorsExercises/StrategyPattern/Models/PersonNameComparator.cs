using System.Collections.Generic;

public class PersonNameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int nameLengthComparement = x.Name.Length.CompareTo(y.Name.Length);
        if (nameLengthComparement != 0)
        {
            return nameLengthComparement;
        }

        return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
    }
}