using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var bankAccountsByID = new Dictionary<int, BankAccount>();

        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] commandArgs = command.Split();
            string commandName = commandArgs[0];
            int bankAccountId = int.Parse(commandArgs[1]);

            switch (commandName)
            {
                case "Create":
                    Create(bankAccountsByID, bankAccountId);
                    break;
                case "Deposit":
                    Deposit(bankAccountsByID, commandArgs, bankAccountId);
                    break;
                case "Withdraw":
                    Withdraw(bankAccountsByID, commandArgs, bankAccountId);
                    break;
                case "Print":
                    Print(bankAccountsByID, bankAccountId);
                    break;
            }

            command = Console.ReadLine();
        }   
    }

    private static void Print(Dictionary<int, BankAccount> bankAccountsByID, int bankAccountId)
    {
        if (!bankAccountsByID.ContainsKey(bankAccountId))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(bankAccountsByID[bankAccountId]); ;
        }
    }

    private static void Withdraw(Dictionary<int, BankAccount> bankAccountsByID, string[] commandArgs, int bankAccountId)
    {
        if (!bankAccountsByID.ContainsKey(bankAccountId))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            try
            {
                double amount = double.Parse(commandArgs[2]);
                bankAccountsByID[bankAccountId].Withdraw(amount);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }

    private static void Deposit(Dictionary<int, BankAccount> bankAccountsByID, string[] commandArgs, int bankAccountId)
    {
        if (!bankAccountsByID.ContainsKey(bankAccountId))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            double amount = double.Parse(commandArgs[2]);
            bankAccountsByID[bankAccountId].Deposit(amount);
        }
    }

    private static void Create(Dictionary<int, BankAccount> bankAccountsByID, int bankAccountId)
    {
        if (!bankAccountsByID.ContainsKey(bankAccountId))
        {
            bankAccountsByID.Add(bankAccountId, new BankAccount() { ID = bankAccountId });
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }
}    