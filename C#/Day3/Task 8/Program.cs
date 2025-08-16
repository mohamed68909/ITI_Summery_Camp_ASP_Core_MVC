namespace Task_8
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] input = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                input[i] = int.Parse(Console.ReadLine());
            }

            int[] evenNumbers, oddNumbers;
            SeparateEvenOdd(input, out evenNumbers, out oddNumbers);

            Console.WriteLine("Even numbers:");
            foreach (int num in evenNumbers)
                Console.Write(num + " ");

            Console.WriteLine("\nOdd numbers:");
            foreach (int num in oddNumbers)
                Console.Write(num + " ");
        }

        static void SeparateEvenOdd(int[] input, out int[] evenNumbers, out int[] oddNumbers)
        {
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();

            foreach (int num in input)
            {
                if (num % 2 == 0)
                    evens.Add(num);
                else
                    odds.Add(num);
            }

            evenNumbers = evens.ToArray();
            oddNumbers = odds.ToArray();
        }
    }
}
