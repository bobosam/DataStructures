using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PolishNotationExpressions
{
    public static class Expression
    {
        public static double CalcInfix(string expression)
        {
            expression = Regex.Replace(expression, @"(-)?\d+(\.\d+)?", " $0 ");
            expression = expression.Trim();
            string[] infix = Regex.Split(expression, @"\s+");
            string[] postfix = InfixToPostfix(infix);
            return CalcPostfix(postfix);
        }

        private static double CalcPostfix(string[] tokens)
        {
            int currIndex = 0;
            Stack<double> stack = new Stack<double>();
            stack.Push(double.Parse(tokens[currIndex]));
            currIndex++;
            double c;
            while (currIndex < tokens.Length)
            {
                if (double.TryParse(tokens[currIndex], out c))
                {
                    stack.Push(double.Parse(tokens[currIndex]));
                }
                else
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    switch (tokens[currIndex])
                    {
                        case "+": stack.Push(b + a); break;
                        case "-": stack.Push(b - a); break;
                        case "*": stack.Push(b * a); break;
                        case "/": stack.Push(b / a); break;
                    }
                }
                currIndex++;
            }

            return stack.Pop();
        }

        private static string[] InfixToPostfix(string[] tokens)
        {
            Stack<string> operatorStack = new Stack<string>();
            Queue<string> outputQueue = new Queue<string>();
            int currIndex = 0;

            while (currIndex < tokens.Length)
            {
                string currToken = tokens[currIndex];
                double c;
                if (double.TryParse(currToken, out c))
                {
                    outputQueue.Enqueue(currToken);
                }
                else if (IsOperator(currToken))
                {
                    while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek())
                        && getPredcedence(operatorStack.Peek()) >= getPredcedence(currToken))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(currToken);
                }
                else if (currToken.Equals("("))
                {
                    operatorStack.Push(currToken);
                }
                else if (currToken.Equals(")"))
                {
                    while (!operatorStack.Peek().Equals("("))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
                else {
                    throw new InvalidOperationException(string.Format("Invalid operator: {0}", currToken));
                }
                currIndex++;
            }

            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue.ToArray();
        }

        private static bool IsOperator(string token)
        {
            if (token.Equals("+") || token.Equals("-") || token.Equals("*") || token.Equals("/"))
            {
                return true;
            }
            return false;
        }

        private static int getPredcedence(string operatorToken)
        {
            switch (operatorToken)
            {
                case "+": return 2;
                case "-": return 2;
                case "*": return 3;
                default: return 3;
            }
        }
    }
}
