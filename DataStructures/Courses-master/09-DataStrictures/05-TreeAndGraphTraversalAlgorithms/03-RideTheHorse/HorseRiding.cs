using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RideTheHorse
{
    public class HorseRiding
    {
        private static readonly int[] positions = { 1, 2, -1, 2, 1, -2, -1, -2, 2, 1, -2, 1, 2, -1, -2, -1 };

        private class Node
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Value { get; set; }

            public Node(int row, int col, int value = 1)
            {
                this.Row = row;
                this.Col = col;
                this.Value = value;
            }
        }

        public static void Ride()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];

            matrix = FillMatrixWithValues(startRow, startCol, matrix);
            PrintResult(matrix.GetLength(1) / 2, matrix);
        }

        public static int[,] FillMatrixWithValues(int startRow, int startCol, int[,] matrix)
        {
            var queue = new Queue<Node>(new Node[] { new Node(startRow, startCol) });

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                matrix[currentNode.Row, currentNode.Col] = currentNode.Value;

                for (int i = 0; i < positions.Length; i += 2)
                {
                    if (IsValidPosition(currentNode.Row + positions[i],
                        currentNode.Col + positions[i + 1], matrix))
                    {
                        queue.Enqueue(new Node(
                            currentNode.Row + positions[i],
                            currentNode.Col + positions[i + 1],
                            currentNode.Value + 1));
                    }
                }
            }
            return matrix;
        }

        public static void PrintResult(int col, int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(matrix[i, col]);
            }
        }

        private static bool IsValidPosition(int currRow, int currCol, int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (currRow < rows && currRow >= 0 && 
                currCol < cols && currCol >= 0 && 
                matrix[currRow, currCol] == 0)
            {
                return true;
            }
            return false;
        }
    }
}

