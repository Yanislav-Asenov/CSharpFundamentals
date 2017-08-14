using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        var jobCollection = new JobCollection();
        EmployeeFactory employeeFactory = new EmployeeFactory();
        IDictionary<string, IEmployee> employeesByName = new Dictionary<string, IEmployee>();

        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] commandArgs = command.Split();
            string commandName = commandArgs[0];

            switch (commandName)
            {
                case "Job":
                    CreateJob(employeesByName, commandArgs, jobCollection);
                    break;
                case "Pass":
                    PassWeek(jobCollection);
                    break;
                case "Status":
                    PrintJobsStatus(jobCollection);
                    break;
                default:
                    CreateEmployee(employeeFactory, employeesByName, commandArgs);
                    break;
            }

            command = Console.ReadLine();
        }
    }

    private static void CreateEmployee(EmployeeFactory employeeFactory, IDictionary<string, IEmployee> employeesByName, string[] commandArgs)
    {
        string employeeType = commandArgs[0];
        string employeeName = commandArgs[1];
        IEmployee employee = employeeFactory.Create(employeeType, employeeName);
        employeesByName.Add(employeeName, employee);
    }

    private static void PrintJobsStatus(JobCollection jobCollection)
    {
        string status = jobCollection.GetJobsStatus();
        Console.WriteLine(status);
    }

    private static void PassWeek(JobCollection jobCollection)
    {
        jobCollection.PassWeek();
    }

    private static void CreateJob(IDictionary<string, IEmployee> employeesByName, string[] commandArgs, JobCollection jobCollection)
    {
        string jobName = commandArgs[1];
        int requiredHours = int.Parse(commandArgs[2]);
        string targetEmployeeName = commandArgs[3];
        IEmployee targetEmployee = employeesByName[targetEmployeeName];
        IJob job = new Job(jobName, requiredHours, targetEmployee);
        jobCollection.Add(job);
    }
}