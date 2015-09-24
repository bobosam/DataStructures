using System;
using System.Linq;
using System.Collections.Generic;

class LongestSequence
{
    public static List<int> getLongestSubsequence(string input)
    {
        List<int> numbers = input.Split(' ').Select(s => int.Parse(s)).ToList<int>();

        int bestIndex = 0;
        int currentBestIndex = 0;
        int currentMax = 1;
        int bestMax = 1;
        bool inSequence = false;

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                if (!inSequence)
                {
                    currentBestIndex = i;
                    inSequence = true;
                }

                currentMax++;

                if (currentMax > bestMax)
                {
                    bestIndex = currentBestIndex;
                    bestMax = currentMax;
                }
            }
            else
            {
                if (inSequence)
                {
                    inSequence = false;
                }
                currentMax = 1;
            }
        }

        return numbers.Skip(bestIndex).Take(bestMax).ToList<int>();
    }
}

