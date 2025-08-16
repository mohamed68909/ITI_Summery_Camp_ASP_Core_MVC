using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of matrix: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int[,] transpose = new int[n, n];

            Console.WriteLine($"Enter {n}x{n} matrix:");

   
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            Console.WriteLine("\nOriginal Matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    transpose[j, i] = matrix[i, j];
                }
            }

            
            Console.WriteLine("\nTransposed Matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(transpose[i, j] + " ");
                }
                Console.WriteLine();
            }

          
            int mainDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            for (int i = 0; i < n; i++)
            {
                mainDiagonalSum += matrix[i, i];
                secondaryDiagonalSum += matrix[i, n - i - 1];
            }

            Console.WriteLine("\nMain Diagonal Sum: " + mainDiagonalSum);
            Console.WriteLine("Secondary Diagonal Sum: " + secondaryDiagonalSum);
        }
    }
}
