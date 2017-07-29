using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Clinic : IEnumerable<Pet>
{
    private string name;
    private int numberOfRooms;
    private Pet[] pets;
    private int startIndex;
    private int leftIndex;
    private int rightIndex;
    private bool isLeftTurn = false;
    private bool isRightTurn = false;

    public Clinic(string name, int numberOfRooms)
    {
        this.Name = name;
        this.NumberOfRooms = numberOfRooms;
        this.startIndex = this.NumberOfRooms / 2;
        this.leftIndex = startIndex - 1;
        this.rightIndex = startIndex + 1;
        this.pets = new Pet[this.NumberOfRooms];
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int NumberOfRooms
    {
        get => this.numberOfRooms;
        set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.numberOfRooms = value;
        }
    }

    public bool AddPet(Pet pet)
    {
        if (!this.isLeftTurn && !this.isRightTurn)
        {
            try
            {
                this.pets[this.startIndex] = pet;
                isLeftTurn = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        else if (this.isLeftTurn)
        {
            return this.AddToTheLeft(pet);
        }
        else if (this.isRightTurn)
        {
            return this.AddToTheRight(pet);
        }
        else
        {
            return false;
        }
    }

    private bool AddToTheRight(Pet pet)
    {
        if (this.rightIndex < this.pets.Length)
        {
            this.pets[this.rightIndex] = pet;
            this.isRightTurn = false;
            this.isLeftTurn = true;
            this.rightIndex++;
            return true;
        }
        else if (this.leftIndex >= 0)
        {
            return this.AddToTheLeft(pet);
        }
        else
        {
            return false;
        }
    }

    private bool AddToTheLeft(Pet pet)
    {
        if (this.leftIndex >= 0)
        {
            this.pets[this.leftIndex] = pet;
            this.isLeftTurn = false;
            this.isRightTurn = true;
            this.leftIndex--;
            return true;
        }
        else if (this.rightIndex < this.pets.Length)
        {
            return this.AddToTheRight(pet);
        }
        else
        {
            return false;
        }
    }

   

    public bool ReleasePet()
    {
        var enumerator = this.GetEnumerator();
        var pet = enumerator.Current;

        if (pet != null)
        {
            return true;
        }

        while (enumerator.MoveNext())
        {
            pet = enumerator.Current;
            if (pet != null)
            {
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            if (pets[i] == null)
            {
                return true;
            }
        }

        return false;
    }

    public void Print()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            Pet pet = this.pets[i];
            if (pet == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(pet);
            }
        }
    }

    public void PrintRoom(int targetRoom)
    {
        Pet pet = this.pets[targetRoom - 1];
        if (pet == null)
        {
            Console.WriteLine("Room empty");
        }
        else
        {
            Console.WriteLine(pet);
        }
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        for (int i = this.startIndex; i < this.pets.Length; i++)
        {
            Pet pet = this.pets[i];

            if (pet != null)
            {
                this.pets[i] = null;
                yield return pet;
                yield break;
            }
        }

        for (int i = this.startIndex - 1; i >= 0; i--)
        {
            Pet pet = this.pets[i];

            if (pet != null)
            {
                this.pets[i] = null;
                yield return pet;
                yield break;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}