namespace BashSoft.IO
{
    using System;
    using BashSoft.Contracts;
    using BashSoft.StaticData;

    public class InputReader : IReader
    {
        private const string EndCommand = "quit";
        private IInterpreter commandInterpreter;

        public InputReader(IInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
            string input = Console.ReadLine().Trim();

            while (input != EndCommand)
            {
                this.commandInterpreter.InterpretCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
