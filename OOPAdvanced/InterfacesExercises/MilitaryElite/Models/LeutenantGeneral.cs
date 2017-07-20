using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<IPrivate>();
    }

    public ICollection<IPrivate> Privates { get; private set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append($"{base.ToString()}{Environment.NewLine}Privates:{Environment.NewLine}");

        this.AppendPrivates(result);

        return result.ToString().Trim();
    }

    private void AppendPrivates(StringBuilder result)
    {
        foreach (var privateSoldier in this.Privates)
        {
            result
                .Append("  " + privateSoldier.ToString())
                .AppendLine();
        }
    }
}