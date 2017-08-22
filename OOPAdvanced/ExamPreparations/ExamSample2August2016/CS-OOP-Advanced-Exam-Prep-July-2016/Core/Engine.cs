namespace CS_OOP_Advanced_Exam_Prep_July_2016.Core
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.Core;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.IO;
    using System;
    using System.Text.RegularExpressions;

    public class Engine : IEngine
    {
        private const string TerminateProgramCommand = "ILIENCI";

        private readonly IInputOutputManager inputOutputManager;
        private readonly IParser parser;

        public Engine(IInputOutputManager inputOutputManager, IParser parser)
        {
            this.inputOutputManager = inputOutputManager;
            this.parser = parser;
        }

        public void Run()
        {
            this.parser.Parse();

            string inputLine = this.inputOutputManager.ReadLine();
            while (inputLine != TerminateProgramCommand)
            {
                string[] commandArgs = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!Enum.TryParse(commandArgs[0], out RequestMethod requestMethod))
                {
                    throw new ArgumentException("Invalid request method type!");
                }

                string commandParametersData = commandArgs[1];
                foreach (var kvp in this.parser.Controllers[requestMethod])
                {
                    Regex requestMappingRegex = new Regex(kvp.Key);
                    
                    if (!requestMappingRegex.IsMatch(commandParametersData))
                    {
                        continue;
                    }

                    ControllerActionPair controllerActionPair = kvp.Value;
                    string[] targetMethodParameters = commandParametersData
                            .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    object[] methodParameters = new object[controllerActionPair.ArgumentsMapping.Count];

                    int methodParameterIndex = 0;
                    foreach (var indexTypePair in controllerActionPair.ArgumentsMapping)
                    {
                        methodParameters[methodParameterIndex] =
                            Convert.ChangeType(targetMethodParameters[indexTypePair.Key], indexTypePair.Value);
                        methodParameterIndex++;
                    }

                    string commandResult = controllerActionPair
                        .Action
                        .Invoke(controllerActionPair.Controller, methodParameters)
                        .ToString();

                    this.inputOutputManager.WriteLine(commandResult);
                }

                inputLine = this.inputOutputManager.ReadLine();
            }
        }
    }
}
