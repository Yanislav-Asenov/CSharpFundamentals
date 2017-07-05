using System;

public class Program
{
    public static void Main()
    {
        string type = Console.ReadLine();
        while (type != "Beast!")
        {
            string[] animalArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Animal animal;

            try
            {
                string name = animalArgs[0];
                string age = animalArgs[1];
                string gender = string.Empty;

                switch (type)
                {
                    case "Dog":
                        gender = animalArgs[2];
                        animal = new Dog(name, age, gender);
                        break;
                    case "Cat":
                        gender = animalArgs[2];
                        animal = new Cat(name, age, gender);
                        break;
                    case "Frog":
                        gender = animalArgs[2];
                        animal = new Frog(name, age, gender);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                    default:
                        animal = new Cat(null, null, null);
                        break;
                }

                PrintAnimal(animal);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }

            type = Console.ReadLine();
        }
    }

    private static void PrintAnimal(Animal animal)
    {
        Console.WriteLine(animal);
        Console.WriteLine(animal.ProduceSound());
    }
}

