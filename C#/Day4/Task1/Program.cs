using System;

namespace Task1
{
   
    enum Gender
    {
        Male,
        Female
    }

    
    struct SubjectResult
    {
        public string SubjectName;
        public int Grade;

        public SubjectResult(string subjectName, int grade)
        {
            SubjectName = subjectName;
            Grade = grade;
        }
    }

  
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public SubjectResult[] Results { get; set; }

        public double CalculateAverage()
        {
            if (Results == null || Results.Length == 0)
                return 0;

            double total = 0;
            foreach (var result in Results)
            {
                total += result.Grade;
            }
            return total / Results.Length;
        }
    }

    class Program
    {
     
        static Student GetTopStudent(Student[] students)
        {
            Student topStudent = null;
            double highestAvg = 0;

            foreach (var student in students)
            {
                double avg = student.CalculateAverage();
                if (topStudent == null || avg > highestAvg)
                {
                    highestAvg = avg;
                    topStudent = student;
                }
            }
            return topStudent;
        }

        static void Main(string[] args)
        {
            
            Student[] students = new Student[3];

            students[0] = new Student
            {
                Id = 1,
                Name = "Ahmed",
                Gender = Gender.Male,
                Results = new SubjectResult[]
                {
                    new SubjectResult("Math", 90),
                    new SubjectResult("Science", 85)
                }
            };

            students[1] = new Student
            {
                Id = 2,
                Name = "Sara",
                Gender = Gender.Female,
                Results = new SubjectResult[]
                {
                    new SubjectResult("English", 88),
                    new SubjectResult("Biology", 92)
                }
            };

            students[2] = new Student
            {
                Id = 3,
                Name = "Omar",
                Gender = Gender.Male,
                Results = new SubjectResult[]
                {
                    new SubjectResult("History", 70),
                    new SubjectResult("Geography", 75)
                }
            };

            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Gender: {student.Gender}");
                Console.WriteLine("Subjects:");
                foreach (var result in student.Results)
                {
                    Console.WriteLine($" - {result.SubjectName}: {result.Grade}");
                }
                Console.WriteLine($"Average: {student.CalculateAverage()}\n");
            }

            // Display top student
            Student topStudent = GetTopStudent(students);
            Console.WriteLine($"Top Student: {topStudent.Name} with average {topStudent.CalculateAverage()}");
        }
    }
}
