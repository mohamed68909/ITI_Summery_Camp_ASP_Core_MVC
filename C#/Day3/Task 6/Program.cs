namespace Task_6
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter number of subjects: ");
            int n = int.Parse(Console.ReadLine());

            int[] scores = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter score {i + 1}: ");
                scores[i] = int.Parse(Console.ReadLine());
            }

            int max, min;
            double average;

            CalculateArrayStats(scores, out max, out min, out average);

            Console.WriteLine($"Maximum Score: {max}");
            Console.WriteLine($"Minimum Score: {min}");
            Console.WriteLine($"Average Score: {average}");
        }

        static void CalculateArrayStats(int[] scores, out int max, out int min, out double average)
        {
            max = scores[0];
            min = scores[0];
            int sum = 0;

            foreach (int score in scores)
            {
                if (score > max)
                    max = score;
                if (score < min)
                    min = score;

                sum += score;
            }

            average = (double)sum / scores.Length;
        }
    }
}
