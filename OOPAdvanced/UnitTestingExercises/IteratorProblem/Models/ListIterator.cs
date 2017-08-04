namespace IteratorProblem.Models
{
    using System;
    using IteratorProblem.Contracts;

    public class ListIterator<T> : IListIterator<T>
    {
        private int currentIndex;
        private T[] items;

        public ListIterator(T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            this.currentIndex = 0;
            this.items = items;
        }

        public T GetCurrent()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.items[this.currentIndex];
        }

        public bool HasNext()
        {
            return this.currentIndex + 1 < this.items.Length;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }
    }
}