using System;
using System.Linq;
using System.Collections.Generic;

class RemoveOddOccurences
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<int> numbers = input.Split(' ').Select(s => int.Parse(s)).ToList<int>();
        List<int> removeList = new List<int>();
        List<int> keepList = new List<int>();
        
        for (int i = 0; i < numbers.Count; i++)
        {
            int occurence = 1;
            if (keepList.Contains(numbers[i]))
            {
                continue;
            }
            for (int k = i + 1; k < numbers.Count; k++)
            {
                if (numbers[i] == numbers[k])
                {
                    occurence++;
                }
            }
            if (occurence % 2 != 0 && !removeList.Contains(numbers[i]))
            {
                removeList.Add(numbers[i]);
            }
            else 
            {
                keepList.Add(numbers[i]);
            }
            occurence = 1;
        }

        foreach (var num in removeList)
        {
            if (numbers.Contains(num))
            {
                numbers.RemoveAll(item => item == num);
            }
        }
        Console.WriteLine(string.Join(" ", numbers.ToList()));
    }
}

