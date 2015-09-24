using System;
using System.Collections.Generic;
using System.Linq;

class CountOfOccurences
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<int> numbers = input.Split(' ').Select(s => int.Parse(s)).ToList<int>();
        var map = new Dictionary<int, int>();

        foreach (var num in numbers)
        {
            if (map.ContainsKey(num))
            {
                map[num]++;
            }
            else
            {
                map[num] = 1;
            }
        }

        var keysList = map.Keys.ToList();
        keysList.Sort();

        foreach (var key in keysList)
        {
            Console.WriteLine("{0} -> {1} times", key, map[key]);
        }
    }
}


