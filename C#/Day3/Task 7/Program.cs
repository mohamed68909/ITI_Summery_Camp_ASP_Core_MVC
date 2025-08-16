namespace Task_7
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int sum;
            ModifyAndSumArray(ref arr, out sum);

            Console.WriteLine("Modified array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine($"\nSum of modified array: {sum}");
        }

        static void ModifyAndSumArray(ref int[] arr, out int sum)
        {
            sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += 5;
                sum += arr[i];
            }
        }
    }
}
