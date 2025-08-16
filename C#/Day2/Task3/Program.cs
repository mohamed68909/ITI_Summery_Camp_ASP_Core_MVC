using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine().ToLower();
            int vowelCount = 0;
            foreach (char c in sentence)
            {
                if ("aeiou".Contains(c))
                {
                    vowelCount++;
                }
            }
            Console.WriteLine("Number of vowels: " + vowelCount);
        }
    }
}
