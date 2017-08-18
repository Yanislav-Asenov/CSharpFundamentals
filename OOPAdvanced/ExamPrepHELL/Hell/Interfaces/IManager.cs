using System.Collections.Generic;

public interface IManager
{
    IDictionary<string, IHero> Heroes { get; }

    string AddHero(IList<string> arguments);

    string AddItemToHero(IList<string> arguments);

    string Inspect(IList<string> arguments);
}