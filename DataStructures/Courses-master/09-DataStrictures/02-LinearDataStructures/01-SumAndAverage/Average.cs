using System;
using System.Collections.Generic;
using System.Linq;

class Average
{
    static void Main()
    {
        string input = Console.ReadLine();
        int sum = 0;
        double average = 0;

        if (!string.IsNullOrEmpty(input))
        {
            List<int> numbers = input.Split(' ').Select(s => int.Parse(s)).ToList<int>();
            sum = numbers.Sum();
            average = sum / (double)numbers.Count;
        }

        Console.WriteLine("Sum={0}; Average={1}", sum, average);
    }
}

