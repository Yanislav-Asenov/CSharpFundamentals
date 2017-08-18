using System.Collections.Generic;
using System.Text;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IList<string> args, IManager manager) 
        : base(args, manager)
    {
    }

    public override string Execute()
    {
        int heroCounter = 1;
        StringBuilder result = new StringBuilder();
        foreach (var hero in this.Manager.Heroes)
        {
            result.AppendLine($"{heroCounter} {hero.ToString()}");
        }

        return result.ToString().Trim();
    }
}