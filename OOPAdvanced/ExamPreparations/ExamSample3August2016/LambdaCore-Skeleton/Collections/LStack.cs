namespace LambdaCore_Skeleton.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using LambdaCore_Skeleton.Interfaces.Collections;

    public class LStack<T> : ILStack<T> where T : class
    {
        private LinkedList<T> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<T>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public T Push(T item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public void Pop()
        {
            this.innerList.RemoveLast();
        }

        public T Peek()
        {
            T peekedItem = this.innerList.First();
            return peekedItem;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
