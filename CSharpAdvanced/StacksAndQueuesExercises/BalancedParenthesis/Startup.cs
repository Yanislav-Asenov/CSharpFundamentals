namespace BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var parenthesisString = Console.ReadLine();

            var closingParenthesis = new Dictionary<char, char>()
            {
                { ']', '[' },
                { '}', '{' },
                { ')', '(' }
            };

            var parenthesisStack = new Stack<char>();
            bool isBalanced = true;
            for (int i = 0; i < parenthesisString.Length; i++)
            {
                var currentBrace = parenthesisString[i];

                if (currentBrace == '{' || currentBrace == '(' || currentBrace == '[')
                {
                    parenthesisStack.Push(currentBrace);
                }
                else
                {
                    if (parenthesisStack.Count > 0)
                    {
                        if (closingParenthesis[currentBrace] == parenthesisStack.Peek())
                        {
                            parenthesisStack.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (parenthesisStack.Count > 0)
            {
                isBalanced = false;
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
