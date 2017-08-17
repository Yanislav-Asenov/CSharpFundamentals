namespace RecyclingStation.BusinessLogic.Core
{
    using RecyclingStation.BusinessLogic.Interfaces.Core;
    using RecyclingStation.BusinessLogic.Interfaces.IO;
    using RecyclingStation.Interfaces.Core;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IRunnable
    {
        private const char SplitMethodNameFromMethodParametersDelimiter = ' ';
        private const char SplitMethodParametersDelimiter = '|';
        private const string TerminateProgramCommandName = "TimeToRecycle";

        private readonly IInputOutputManager inputOutputManager;
        private readonly IRecyclingManager recyclingManager;

        private readonly MethodInfo[] recyclingManagerMethods;

        public Engine(IInputOutputManager inputOutputManager, IRecyclingManager recyclingManager)
        {
            this.inputOutputManager = inputOutputManager;
            this.recyclingManager = recyclingManager;

            this.recyclingManagerMethods = this.GetRecyclingManagerMethods();
        }

        private MethodInfo[] GetRecyclingManagerMethods()
        {
            return this.recyclingManager.GetType().GetMethods();
        }

        public void Run()
        {
            string inputLine = this.inputOutputManager.ReadLine();
            while (inputLine != TerminateProgramCommandName)
            {
                string[] commandArgs = this.SplitStringByDelimiter(inputLine, SplitMethodNameFromMethodParametersDelimiter);

                string methodName = commandArgs[0];
                string[] methodParameters = default(string[]);

                if (commandArgs.Length > 1)
                {
                    methodParameters = this.SplitStringByDelimiter(commandArgs[1], SplitMethodParametersDelimiter);
                }

                MethodInfo targetMethod = this.recyclingManagerMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                if (targetMethod == null)
                {
                    throw new ArgumentException("Invalid command name!");
                }

                object[] targetMethodParsedParameters = this.GetParsedParametersForTargetMethod(methodParameters, targetMethod);

                object result = targetMethod.Invoke(this.recyclingManager, targetMethodParsedParameters);
                this.inputOutputManager.AppendLine(result.ToString());

                inputLine = this.inputOutputManager.ReadLine();
            }

            this.inputOutputManager.Write();
        }

        private object[] GetParsedParametersForTargetMethod(string[] methodParameters, MethodInfo targetMethod)
        {
            ParameterInfo[] targetMethodParameters = targetMethod.GetParameters();
            object[] targetMethodParsedParameters = new object[targetMethodParameters.Length];
            for (int i = 0; i < targetMethodParameters.Length; i++)
            {
                Type targetParameterType = targetMethodParameters[i].ParameterType;

                targetMethodParsedParameters[i] = Convert.ChangeType(methodParameters[i], targetParameterType);
            }

            return targetMethodParsedParameters;
        }

        private string[] SplitStringByDelimiter(string stringToSplit, params char[] delimiters)
        {
            return stringToSplit.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
