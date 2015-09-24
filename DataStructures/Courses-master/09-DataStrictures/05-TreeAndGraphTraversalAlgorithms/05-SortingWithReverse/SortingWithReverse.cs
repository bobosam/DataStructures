using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_SortingWithReverse
{
    class SortingWithReverse
    {
        private class Sequence
        {
            public int[] Value { get; set; }
            public Sequence Previous { get; set; }

            public Sequence(int[] value, Sequence previous)
            {
                this.Value = value;
                this.Previous = previous;
            }
        }

        private static Queue<Sequence> candidatesQueue = new Queue<Sequence>();
        private static Sequence sortedSequence = null;
        private static HashSet<string> uniqueSet = new HashSet<string>();
        private static int reverseFactor;
        static bool found = false;
  
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[] initialSequence = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            reverseFactor = int.Parse(Console.ReadLine());
            candidatesQueue.Enqueue(new Sequence(initialSequence, null));
            Console.WriteLine();

            if (!IsSorted(initialSequence))
            {
                while (candidatesQueue.Count > 0)
                {
                    if (found)
                    {
                        break;
                    }
                    GenerateAllSequencesWithSingleReverse(candidatesQueue.Peek());
                    uniqueSet.Add(GetHashCode(candidatesQueue.Dequeue().Value));
                }
                PrintResult(sortedSequence);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void PrintResult(Sequence sortedSequence)
        {
            int operations = -1;
            var path = new List<String>();
            while (sortedSequence != null)
            {
                operations++;
                path.Add(string.Join(" ", sortedSequence.Value));
                sortedSequence = sortedSequence.Previous;
            }
            Console.WriteLine(operations);
            Console.WriteLine();
            Console.WriteLine(string.Join(" -> ", path.ToArray().Reverse()));
        }

        private static void GenerateAllSequencesWithSingleReverse(Sequence sequence)
        {
            for (int i = 0; i < sequence.Value.Length - reverseFactor + 1; i++)
            {
                int[] candidate = ReverseSequence(i, sequence.Value);
                if (IsSorted(candidate) || IsSorted(candidatesQueue.Peek().Value))
                {
                    sortedSequence = new Sequence(candidate, candidatesQueue.Peek());
                    found = true;
                    return;
                }

                string key = GetHashCode(candidate);
                if (!uniqueSet.Contains(key))
                {
                    uniqueSet.Add(key);
                    candidatesQueue.Enqueue(new Sequence(candidate, candidatesQueue.Peek()));
                }
            }
        }

        private static bool IsSorted(int[] sequence)
        {
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] < sequence[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static int[] ReverseSequence(int start, int[] sequence)
        {
            int[] reversed = new int[sequence.Length];
            Array.Copy(sequence, reversed, sequence.Length);
            int[] temp = new int[reverseFactor];
            Array.Copy(sequence, start, temp, 0, reverseFactor);
            Array.Reverse(temp);
            Array.Copy(temp, 0, reversed, start, reverseFactor);

            return reversed;
        }

        private static string GetHashCode(int[] arr)
        {
            return string.Join(".", arr);
        }
    }
}
