namespace Task_3
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of elements: ");
            int size = int.Parse(Console.ReadLine());

            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            ReverseArray(ref numbers);

            Console.WriteLine("Array after reversing:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }

        static void ReverseArray(ref int[] numbers)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int temp = numbers[left];
                numbers[left] = numbers[right];
                numbers[right] = temp;

                left++;
                right--;
            }
        }
    }
}
