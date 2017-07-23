namespace BashSoft.IO
{
    using System;
    using BashSoft.StaticData;
    using BashSoft.Contracts;

    public class InputReader : IReader
    {
        private const string endCommand = "quit";
        private IInterpreter commandInterpreter;

        public InputReader(IInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                this.commandInterpreter.InterpretCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
