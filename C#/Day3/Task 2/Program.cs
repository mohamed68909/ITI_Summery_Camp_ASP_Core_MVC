namespace Task_2
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Before swapping: num1 = {num1}, num2 = {num2}");

            SwapValues(ref num1, ref num2);

            Console.WriteLine($"After swapping: num1 = {num1}, num2 = {num2}");
        }

        static void SwapValues(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
