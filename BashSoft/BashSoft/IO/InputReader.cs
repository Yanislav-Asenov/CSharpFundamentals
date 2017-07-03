namespace BashSoft.IO
{
    using System;
    using BashSoft.StaticData;

    public class InputReader
    {
        private const string endCommand = "quit";
        private CommandInterpreter commandInterpreter;

        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                this.commandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
