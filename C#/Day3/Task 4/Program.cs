namespace Task_4
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter the dividend: ");
            int dividend = int.Parse(Console.ReadLine());

            Console.Write("Enter the divisor: ");
            int divisor = int.Parse(Console.ReadLine());

            int quotient, remainder;

            DivideAndRemainder(dividend, divisor, out quotient, out remainder);

            Console.WriteLine($"Quotient: {quotient}");
            Console.WriteLine($"Remainder: {remainder}");
        }

        static void DivideAndRemainder(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }
    }
}
