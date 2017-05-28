    namespace SoftUniParty
    {
        using System;
        using System.Collections.Generic;

        public class Startup
        {
            public static void Main()
            {
                string inputLine = Console.ReadLine();

                SortedSet<string> vipGuests = new SortedSet<string>();
                SortedSet<string> regularGuests = new SortedSet<string>();
                while (inputLine != "PARTY")
                {
                    if (IsNumberVIP(inputLine))
                    {
                        vipGuests.Add(inputLine);
                    }
                    else
                    {
                        regularGuests.Add(inputLine);
                    }

                    inputLine = Console.ReadLine();
                }

                inputLine = Console.ReadLine();
                while (inputLine != "END")
                {
                    if (vipGuests.Contains(inputLine))
                    {
                        vipGuests.Remove(inputLine);
                    }
                    else if (regularGuests.Contains(inputLine))
                    {
                        regularGuests.Remove(inputLine);
                    }

                    inputLine = Console.ReadLine();
                }

                Console.WriteLine(vipGuests.Count + regularGuests.Count);

                foreach (var item in vipGuests)
                {
                    Console.WriteLine(item);
                }

                foreach (var item in regularGuests)
                {
                    Console.WriteLine(item);
                }
            }

            private static bool IsNumberVIP(string inputLine)
            {
                return char.IsDigit(inputLine[0]);
            }
        }
    }
