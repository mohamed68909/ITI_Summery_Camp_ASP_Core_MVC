using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int studentsCount = int.Parse(Console.ReadLine());

            int[][] marks = new int[studentsCount][];

            for (int i = 0; i < studentsCount; i++)
            {
                Console.WriteLine($"\nStudent {i + 1}:");
                Console.Write("Enter number of subjects: ");
                int subjectsCount = int.Parse(Console.ReadLine());

                marks[i] = new int[subjectsCount];

                int total = 0;

                for (int j = 0; j < subjectsCount; j++)
                {
                    Console.Write($"Enter mark for subject {j + 1}: ");
                    marks[i][j] = int.Parse(Console.ReadLine());
                    total += marks[i][j];
                }

                double average = (double)total / subjectsCount;

                Console.WriteLine($"Total Marks: {total}");
                Console.WriteLine($"Average Marks: {average}");
            }
        }
    }
}
