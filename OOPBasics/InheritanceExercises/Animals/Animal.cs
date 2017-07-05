using System;

public abstract class Animal : SoundProducible
{
    private string name;
    private string gender;
    private string age;

    public Animal(string name, string age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public virtual string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    public virtual string Gender
    {
        get => this.gender;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public virtual string Age
    {
        get => this.age;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            if (!int.TryParse(value, out int ageAsInt))
            {
               
                throw new ArgumentException("Invalid input!");
            }
            else
            {
                if (ageAsInt <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
            }

            this.age = value;
        }
    }

    public override string ProduceSound()
    {
        return base.ProduceSound();
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}{this.Name} {this.Age} {this.Gender}";
    }
}

