namespace BashSoft
{
    using BashSoft.IO;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class Launcher
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager inputOutputManager = new IOManager();
            StudentsRepository repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            CommandInterpreter commandInterpreter = new CommandInterpreter(tester, repository, inputOutputManager);
            InputReader reader = new InputReader(commandInterpreter);

            reader.StartReadingCommands();
        }
    }
}
