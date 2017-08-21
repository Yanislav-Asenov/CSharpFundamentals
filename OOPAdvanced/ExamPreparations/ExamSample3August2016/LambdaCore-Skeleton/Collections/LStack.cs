namespace LambdaCore_Skeleton.Collections
{
    using System.Collections.Generic;
    using System.Linq;
    using LambdaCore_Skeleton.Interfaces.Collections;
    using LambdaCore_Skeleton.Interfaces.Models;

    public class LStack : ILStack
    {
        private LinkedList<ICore> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<ICore>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public ICore Push(ICore item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public void Pop()
        {
            this.innerList.RemoveLast();
        }

        public ICore Peek()
        {
            ICore peekedItem = this.innerList.First();
            return peekedItem;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}
