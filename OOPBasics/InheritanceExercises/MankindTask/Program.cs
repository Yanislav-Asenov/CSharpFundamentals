using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string[] studentArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Student student = new Student(studentArgs[0], studentArgs[1], studentArgs[2]);

            string[] workerArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Worker worker = new Worker(workerArgs[0], workerArgs[1], decimal.Parse(workerArgs[2]), decimal.Parse(workerArgs[3]));

            Console.WriteLine(student);
            Console.Write(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}

