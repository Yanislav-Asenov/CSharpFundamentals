using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static IDictionary<string, Pet> petsByName = new Dictionary<string, Pet>();
    private static IDictionary<string, Clinic> clinicsByName = new Dictionary<string, Clinic>();

    public static void Main()
    {
        int numberOfInputLine = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputLine; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();
            string commandName = commandArgs[0];

            string[] args = commandArgs.Skip(1).ToArray();
            switch (commandName)
            {
                case "Create":
                    ExecuteCreateCommand(args);
                    break;
                case "Add":
                    ExecuteAddCommand(args);
                    break;
                case "Release":
                    ExecuteReleaseCommand(args);
                    break;
                case "HasEmptyRooms":
                    ExecuteHasEmptyRoomsCommand(args);
                    break;
                case "Print":
                    ExecutePrintCommand(args);
                    break;
                default:
                    break;
            }
        }
    }

    private static void ExecutePrintCommand(string[] args)
    {
        if (args.Length == 1)
        {
            PrintClinic(args[0]);
        }
        else
        {
            PrintRoom(args[0], int.Parse(args[1]));
        }
    }

    private static void PrintRoom(string clinicName, int roomNumber)
    {
        clinicsByName[clinicName].PrintRoom(roomNumber);
    }

    private static void PrintClinic(string clinicName)
    {
        clinicsByName[clinicName].Print();
    }

    

    private static void ExecuteHasEmptyRoomsCommand(string[] args)
    {
        string clinicName = args[0];
        Clinic targetClinic = clinicsByName[clinicName];
        Console.WriteLine(targetClinic.HasEmptyRooms());
    }

    private static void ExecuteReleaseCommand(string[] args)
    {
        string clinicName = args[0];
        Clinic targetClinic = clinicsByName[clinicName];
        Console.WriteLine(targetClinic.ReleasePet());
    }

    private static void ExecuteAddCommand(string[] args)
    {
        string petName = args[0];
        string clinicName = args[1];

        Pet targetPet = petsByName[petName];
        Clinic targetClinic = clinicsByName[clinicName];
        Console.WriteLine(targetClinic.AddPet(targetPet));
    }

    private static void ExecuteCreateCommand(string[] args)
    {
        string objectType = args[0];
        switch (objectType)
        {
            case "Pet":
                string petName = args[1];
                int petAge = int.Parse(args[2]);
                string petKind = args[3];
                Pet pet = new Pet(petName, petAge, petKind);
                petsByName.Add(petName, pet);
                break;
            case "Clinic":
                string clinicName = args[1];
                int clinicNumberOfRooms = int.Parse(args[2]);
                try
                {
                    Clinic clinic = new Clinic(clinicName, clinicNumberOfRooms);
                    clinicsByName.Add(clinicName, clinic);
                }
                catch
                {
                    Console.WriteLine("Invalid Operation!");
                }
                break;
            default:
                break;
        }
    }
}