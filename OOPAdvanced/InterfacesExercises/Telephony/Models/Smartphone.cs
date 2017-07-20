using System.Text.RegularExpressions;

public class Smartphone : ISmartphone
{
    public string Browse(string url)
    {
        if (this.IsUrlValid(url))
        {
            return $"Browsing: {url}!";
        }

        return "Invalid URL!";
    }

    public string Call(string number)
    {
        if (this.IsNumberValid(number))
        {
            return $"Calling... {number}";
        }

        return "Invalid number!";
    }

    private bool IsUrlValid(string url)
    {
        string pattern = @"[0-9]";
        Regex regex = new Regex(pattern);

        if (regex.IsMatch(url))
        {
            return false;
        }

        return true;
    }

    private bool IsNumberValid(string number)
    {
        string pattern = @"\D";
        Regex regex = new Regex(pattern);

        if (regex.IsMatch(number))
        {
            return false;
        }

        return true;
    }
}