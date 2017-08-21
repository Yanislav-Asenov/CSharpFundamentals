namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Interfaces.Core;

    public class CoreIdManager : ICoreIdManager
    {
        private const char CoreStartingName = 'A';

        private char currentName = CoreStartingName;

        public char GetNext()
        {
            return this.currentName++;
        }
    }
}
