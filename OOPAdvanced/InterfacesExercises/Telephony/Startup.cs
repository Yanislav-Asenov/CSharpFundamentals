using System;
using System.Text;

public class Startup
{
    public static void Main()
    {
        ISmartphone smartphone = new Smartphone();

        string[] phoneNumbersToCall = Console.ReadLine().Split();
        CallPhoneNumbers(smartphone, phoneNumbersToCall);

        string[] webSitesToVisit = Console.ReadLine().Split();
        BrowseWebSites(smartphone, webSitesToVisit);
    }

    private static void BrowseWebSites(IBrowsable browser, string[] webSites)
    {
        StringBuilder result = new StringBuilder();

        foreach (var webSite in webSites)
        {
            result.AppendLine(browser.Browse(webSite));
        }

        Console.Write(result);
    }

    private static void CallPhoneNumbers(ICallable phone, string[] phoneNumbers)
    {
        StringBuilder result = new StringBuilder();

        foreach (var phoneNumber in phoneNumbers)
        {
            result.AppendLine(phone.Call(phoneNumber));
        }

        Console.Write(result);
    }
}