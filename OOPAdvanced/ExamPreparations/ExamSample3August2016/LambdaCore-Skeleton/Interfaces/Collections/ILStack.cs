namespace LambdaCore_Skeleton.Interfaces.Collections
{
    using LambdaCore_Skeleton.Interfaces.Models;

    public interface ILStack
    {
        int Count();

        ICore Push(ICore item);

        void Pop();

        ICore Peek();

        bool IsEmpty();
    }
}
