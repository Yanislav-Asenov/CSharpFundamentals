namespace BubbleSortProblem.Models
{
    using System;
    using BubbleSortProblem.Contracts;

    public class Bubble : IBubble
    {
        public void Sort(int[] items)
        {
            while (true)
            {
                bool isSorted = true;

                for (int i = 0; i < items.Length - 1; i++)
                {
                    int currentItem = items[i];
                    int nextItem = items[i + 1];

                    if (currentItem > nextItem)
                    {
                        items[i] = nextItem;
                        items[i + 1] = currentItem;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }
        }
    }
}