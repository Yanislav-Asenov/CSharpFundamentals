using System;

public class Startup
{
    public static void Main()
    {
        var primitiveCalculator = new PrimitiveCalculator();

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandArgs = command.Split();

            if (commandArgs[0] == "mode")
            {
                char mode = char.Parse(commandArgs[1]);
                primitiveCalculator.ChangeStrategy(mode);
            }
            else
            {
                int firstOperand = int.Parse(commandArgs[0]);
                int secondOperand = int.Parse(commandArgs[1]);
                int result = primitiveCalculator.PerformCalculation(firstOperand, secondOperand);
                Console.WriteLine(result);
            }

            command = Console.ReadLine();
        }
    }
}