namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            var phoneBook = new Dictionary<string, string>();

            while (!command.Equals("search"))
            {
                string[] infoArgs = command.Split('-');
                string name = infoArgs[0];
                string phoneNumber = infoArgs[1];

                phoneBook[name] = phoneNumber;

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (!command.Equals("stop"))
            {
                string name = command;

                if (phoneBook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phoneBook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }

                command = Console.ReadLine();
            }
        }
    }
}
