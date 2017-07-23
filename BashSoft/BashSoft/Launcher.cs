namespace BashSoft
{
    using BashSoft.Contracts;
    using BashSoft.IO;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class Launcher
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryMananger inputOutputManager = new IOManager();
            IDatabase repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter commandInterpreter = new CommandInterpreter(tester, repository, inputOutputManager);
            IReader reader = new InputReader(commandInterpreter);

            reader.StartReadingCommands();
        }
    }
}