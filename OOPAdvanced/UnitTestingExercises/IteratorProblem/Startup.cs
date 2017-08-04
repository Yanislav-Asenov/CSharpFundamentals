namespace IteratorProblem
{
    using IteratorProblem.Contracts;
    using IteratorProblem.Models;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            IListIterator<string> listIterator = null;

            string inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                string[] commandArgs = inputLine.Split();
                string command = commandArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string[] items = commandArgs.Skip(1).ToArray();
                            listIterator = new ListIterator<string>(items);
                            break;
                        case "HasNext":
                            Console.WriteLine(listIterator.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(listIterator.Move());
                            break;
                        case "Print":
                            Console.WriteLine(listIterator.GetCurrent());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}