namespace Task5
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            int age;
            double grade;

            GetStudentInfo(name, out age, out grade);

            Console.WriteLine($"Student Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Grade: {grade}");
        }

        static void GetStudentInfo(string name, out int age, out double grade)
        {
            age = 20;
            grade = 85.5;
        }
    }
}
