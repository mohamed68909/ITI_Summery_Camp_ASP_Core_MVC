using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                Console.Write("How many numbers? ");
                int n = int.Parse(Console.ReadLine());

                int[] numbers = new int[n];
                Console.WriteLine("Enter numbers:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Number {i + 1}: ");
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("Prime numbers: ");
                int sumOfPrimes = 0;
                for (int i = 0; i < n; i++)
                {
                    bool isPrime = true;

                    if (numbers[i] <= 1)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        for (int j = 2; j <= Math.Sqrt(numbers[i]); j++)
                        {
                            if (numbers[i] % j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                    }

                    if (isPrime)
                    {
                        Console.Write(numbers[i] + " ");
                        sumOfPrimes += numbers[i];
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Sum of primes: " + sumOfPrimes);

                Array.Sort(numbers);
                Array.Reverse(numbers);
                Console.WriteLine("Sorted array: " + string.Join(" ", numbers));
            
            
        }
    }
}
