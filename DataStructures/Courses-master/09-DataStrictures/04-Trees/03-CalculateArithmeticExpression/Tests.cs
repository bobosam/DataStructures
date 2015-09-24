using System;
using PolishNotationExpressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Tests
{
    static void Main()
    {
        Console.WriteLine(Expression.CalcInfix("5 + 6"));
        Console.WriteLine(Expression.CalcInfix("(2 + 3) * 4.5"));
        Console.WriteLine(Expression.CalcInfix("-2 - -1"));
        //Console.WriteLine(Expression.CalcInfix("3 ++ 4"));
        Console.WriteLine(Expression.CalcInfix("1.5 - 2.5 * 2 * (-3)"));
        Console.WriteLine(Expression.CalcInfix("1/2"));
    }
}

