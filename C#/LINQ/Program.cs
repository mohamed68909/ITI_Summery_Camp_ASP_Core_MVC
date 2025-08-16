namespace LINQ
{
    internal class Program
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Department { get; set; }
            public double GPA { get; set; }
        }

      
            static void Main()
            {
                List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Ahmed", Age = 20, Department = "Computer Science", GPA = 3.8 },
                new Student { Id = 2, Name = "Sara", Age = 22, Department = "Business", GPA = 3.4 },
                new Student { Id = 3, Name = "Youssef", Age = 19, Department = "Computer Science", GPA = 3.6 },
                new Student { Id = 4, Name = "Mona", Age = 21, Department = "Engineering", GPA = 3.2 },
                new Student { Id = 5, Name = "Omar", Age = 23, Department = "Computer Science", GPA = 3.9 },
                new Student { Id = 6, Name = "Laila", Age = 20, Department = "Engineering", GPA = 3.1 },
                new Student { Id = 7, Name = "Khaled", Age = 24, Department = "Business", GPA = 3.7 },
                new Student { Id = 8, Name = "Hana", Age = 18, Department = "Computer Science", GPA = 2.9 },
                new Student { Id = 9, Name = "Tamer", Age = 22, Department = "Engineering", GPA = 3.3 },
                new Student { Id = 10, Name = "Nour", Age = 21, Department = "Business", GPA = 3.6 }
            };

                // 1. Students with GPA > 3.5
                var highGPA = students.Where(s => s.GPA > 3.5);
                Console.WriteLine("Students with GPA > 3.5:");
                foreach (var s in highGPA)
                    Console.WriteLine($"- {s.Name} ({s.GPA})");

                // 2. Average GPA
                var avgGPA = students.Average(s => s.GPA);
                Console.WriteLine($"\nAverage GPA: {avgGPA:F2}");

                // 3. Students sorted by name
                var sortedByName = students.OrderBy(s => s.Name);
                Console.WriteLine("\nStudents sorted by name:");
                foreach (var s in sortedByName)
                    Console.WriteLine($"- {s.Name}");

                // 4. Group students by department
                var groupedByDept = students.GroupBy(s => s.Department);
                Console.WriteLine("\nStudents grouped by department:");
                foreach (var group in groupedByDept)
                {
                    Console.WriteLine($"Department: {group.Key}");
                    foreach (var s in group)
                        Console.WriteLine($"  - {s.Name}");
                }

                // 5. Count students in each department
                var countByDept = students
                    .GroupBy(s => s.Department)
                    .Select(g => new { Department = g.Key, Count = g.Count() });
                Console.WriteLine("\nNumber of students in each department:");
                foreach (var d in countByDept)
                    Console.WriteLine($"- {d.Department}: {d.Count}");

                // 6. Student with highest GPA
                var topStudent = students.OrderByDescending(s => s.GPA).First();
                Console.WriteLine($"\nTop student: {topStudent.Name} ({topStudent.GPA})");

                // 7. Are all students older than 18?
                bool allAbove18 = students.All(s => s.Age > 18);
                Console.WriteLine($"\nAll students older than 18? {allAbove18}");

                // 8. Names of CS students
                var csStudents = students
                    .Where(s => s.Department == "Computer Science")
                    .Select(s => s.Name);
                Console.WriteLine("\nComputer Science students:");
                foreach (var name in csStudents)
                    Console.WriteLine($"- {name}");

                // 9. Top 3 students by GPA
                var top3 = students
                    .OrderByDescending(s => s.GPA)
                    .Take(3);
                Console.WriteLine("\nTop 3 students by GPA:");
                foreach (var s in top3)
                    Console.WriteLine($"- {s.Name} ({s.GPA})");
            }
        }
    }

