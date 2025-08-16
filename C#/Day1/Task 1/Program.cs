using System;

class Program
{
    static void Main()
    {
        Console.Write("How many numbers will you enter? ");
        int count = int.Parse(Console.ReadLine());

        int sum = 0;
        int evenCount = 0;
        int oddCount = 0;
        int max = int.MinValue;
        int min = int.MaxValue;

        for (int i = 1; i <= count; i++)
        {
            Console.Write($"Enter number {i}: ");
            int num = int.Parse(Console.ReadLine());

            sum += num;

            if (num % 2 == 0)
                evenCount++;
            else
                oddCount++;

            if (num > max)
                max = num;

            if (num < min)
                min = num;
        }

        Console.WriteLine();

        if (evenCount > oddCount)
            Console.WriteLine("Most of your numbers are even.");
        else if (oddCount > evenCount)
            Console.WriteLine("Most of your numbers are odd.");
        else
            Console.WriteLine("You have an equal number of even and odd numbers.");

        double average = (double)sum / count;

        Console.WriteLine($"\nSum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Min: {min}");
    }
}
