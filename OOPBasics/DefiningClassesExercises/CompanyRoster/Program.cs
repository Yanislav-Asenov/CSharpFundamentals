using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] inputLineArgs = Console.ReadLine().Split();

            string name = inputLineArgs[0];
            decimal salary = decimal.Parse(inputLineArgs[1]);
            string position = inputLineArgs[2];
            string department = inputLineArgs[3];
            Employee employee = new Employee(name, salary, position, department);

            if (inputLineArgs.Length > 5)
            {
                if (int.TryParse(inputLineArgs[4], out int age))
                {
                    employee.Age = age;    
                    employee.Email = inputLineArgs[5];
                }
                else
                {
                    employee.Age = int.Parse(inputLineArgs[5]);
                    employee.Email = inputLineArgs[4];
                }
            }
            else if (inputLineArgs.Length > 4)
            {
                if (int.TryParse(inputLineArgs[4], out int age))
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = inputLineArgs[4];
                }
            }

            employees.Add(employee);
        }

        var employeesGroupedByDepartment = employees.GroupBy(e => e.Department);

        var highestAverageSalaryDepartment = employeesGroupedByDepartment
            .Select(g => new
            {
                Name = g.Key,
                AverageSalary = g.Average(e => e.Salary),
                Employees = g.Select(x => x)
            })
            .OrderByDescending(g => g.AverageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.Name}");
        foreach (var employee in highestAverageSalaryDepartment.Employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine(employee);
        }
    }
}

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, decimal salary, string position, string department, string email = "n/a", int age = -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:F2} {this.Email} {this.Age}";
    }
}
