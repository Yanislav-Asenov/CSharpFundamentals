using System;

public class Sorter<T> where T : IComparable<T>
{
    public static void Sort(CustomList<T> customList)
    {
        int elementIndex = 0;
        foreach (var element in customList)
        {
            int elementToSwapIndex = 0;
            foreach (var elementToSwap in customList)
            {
                if (element.CompareTo(elementToSwap) > 0)
                {
                    customList.Swap(elementIndex, elementToSwapIndex);
                }

                elementToSwapIndex++;
            }
            elementIndex++;
        }
    }
}