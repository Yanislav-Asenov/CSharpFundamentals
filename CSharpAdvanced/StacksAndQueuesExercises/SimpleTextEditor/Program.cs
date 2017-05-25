namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var numberOfOperations = int.Parse(Console.ReadLine());

            var history = new Stack<string>();
            StringBuilder text = new StringBuilder();
            text.Append("");

            for (int i = 0; i < numberOfOperations; i++)
            {
                var operationArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (operationArgs[0])
                {
                    case "1":
                        history.Push(text.ToString());
                        text.Append(operationArgs[1]);
                        break;
                    case "2":
                        var numberOfCharsToErase = int.Parse(operationArgs[1]);

                        if (numberOfCharsToErase > text.Length)
                        {
                            numberOfCharsToErase = text.Length;
                        }

                        history.Push(text.ToString());
                        text.Remove(text.Length - numberOfCharsToErase, numberOfCharsToErase);
                        break;
                    case "3":
                        var targetIndex = int.Parse(operationArgs[1]);
                        Console.WriteLine(text[targetIndex - 1]);
                        break;
                    case "4":
                        text.Clear().Append(history.Pop());
                        break;
                }
            }
        }
    }
}
