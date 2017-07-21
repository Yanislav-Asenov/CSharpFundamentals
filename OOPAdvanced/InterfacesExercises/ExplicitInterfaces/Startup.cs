using System;

public class Startup
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] citizenArgs = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = citizenArgs[0];
            string country = citizenArgs[1];
            int age = int.Parse(citizenArgs[2]);
            Citizen citizen = new Citizen(name, country, age);

            IPerson person = citizen;
            IResident resident = citizen;

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());

            inputLine = Console.ReadLine();
        }
    }
}