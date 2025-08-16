namespace Taskes
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter your current salary: ");
            int salary = int.Parse(Console.ReadLine());
            AddBonus(ref salary);
            Console.WriteLine("Your updated salary after bonus is: " + salary);
        }

        static void AddBonus(ref int salary)
        {
            salary += 1000;
        }
    }
}
