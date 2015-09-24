using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace Problem02CountSymbols
{
    public class Problem02CountSymbols
    {
        static void Main()
        {
            string stringText = Console.ReadLine();
            var symbolsColection = new HashTable<char, int>();

            for (int i = 0; i < stringText.Length; i++)
            {
                char symbol = stringText[i];
                if (!symbolsColection.ContainsKey(symbol))
                {
                    symbolsColection.Add(symbol, 1);
                }
                else
                {
                                       symbolsColection[symbol]++;
                }
            }

            var sortedSymbolsColection = symbolsColection.OrderBy(s => s.Key);

            foreach (var symbol in sortedSymbolsColection)
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
