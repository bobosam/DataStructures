using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var countOfCharacterOccurrences = new HashTable<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!countOfCharacterOccurrences.ContainsKey(currentChar))
                {
                    countOfCharacterOccurrences[currentChar] = 0;
                }

                countOfCharacterOccurrences[currentChar]++;
            }

            var CharacterOccurrencesSortedByKey = countOfCharacterOccurrences.OrderBy(e => e.Key);

            foreach (var element in CharacterOccurrencesSortedByKey)
            {
                Console.WriteLine("{0}: {1} time/s", element.Key, element.Value);
            }
        }
    }
}
