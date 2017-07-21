using System;
using System.Text;

public class Startup
{
    public static void Main()
    {
        IAddable addCollection = new AddCollection();
        ICollection addRemoveCollection = new AddRemoveCollection();
        IMyList myList = new MyList();

        string[] itemsForInsert = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder addCollectionAddOperationResults = new StringBuilder();
        StringBuilder addRemoveCollectionAddOperationResults = new StringBuilder();
        StringBuilder myListAddOperationResults = new StringBuilder();
        foreach (var item in itemsForInsert)
        {
            addCollectionAddOperationResults.Append(addCollection.Add(item) + " ");
            addRemoveCollectionAddOperationResults.Append(addRemoveCollection.Add(item) + " ");
            myListAddOperationResults.Append(myList.Add(item) + " ");
        }
        Console.WriteLine(addCollectionAddOperationResults.ToString().Trim());
        Console.WriteLine(addRemoveCollectionAddOperationResults.ToString().Trim());
        Console.WriteLine(myListAddOperationResults.ToString().Trim());

        StringBuilder addRemoveCollectionRemoveOperationResults = new StringBuilder();
        StringBuilder myListRemoveOperationResults = new StringBuilder();
        int numberOfRemoveOperations = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfRemoveOperations; i++)
        {
            addRemoveCollectionRemoveOperationResults.Append(addRemoveCollection.Remove() + " ");
            myListRemoveOperationResults.Append(myList.Remove() + " ");
        }
        Console.WriteLine(addRemoveCollectionRemoveOperationResults.ToString().Trim());
        Console.WriteLine(myListRemoveOperationResults.ToString().Trim());
    }
}