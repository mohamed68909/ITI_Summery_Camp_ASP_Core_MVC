namespace Delegate_Tasks_for_Students
{
    
    public delegate double Operation(double x, double y);

    
    public delegate void Logger(string message);

    public class Calculator
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => b != 0 ? a / b : double.NaN;
    }

    public class LoggerUtil
    {
        public static void LogToConsole(string msg)
        {
            Console.WriteLine($"[Console] {msg}");
        }

        public static void LogToFile(string msg)
        {
            Console.WriteLine($"[FileLog] {msg} (simulated)");
        }
    }

    class Program
    {
        public static double Execute(double x, double y, Operation op)
        {
            return op(x, y);
        }

        static void Main()
        {
            Console.Write("Enter number 1: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number 2: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose operation:\n1-Add\n2-Subtract\n3-Multiply\n4-Divide");
            int choice = Convert.ToInt32(Console.ReadLine());

            Operation selectedOp = choice switch
            {
                1 => Calculator.Add,
                2 => Calculator.Subtract,
                3 => Calculator.Multiply,
                4 => Calculator.Divide,
                _ => throw new Exception("Invalid choice")
            };

            double result = Execute(a, b, selectedOp);

            Logger logger = LoggerUtil.LogToConsole;
            logger += LoggerUtil.LogToFile;

            logger($"Result of operation is: {result}");
        }
    }
}
