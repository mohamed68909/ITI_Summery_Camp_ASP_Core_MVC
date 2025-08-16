using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;

namespace collection
{
 
    

struct Student
    {
        public int Id;
        public string Name;

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"[ID: {Id}] {Name}";
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static Dictionary<int, double> grades = new Dictionary<int, double>();
        static HashSet<string> namesSet = new HashSet<string>();
        static SortedDictionary<string, double> topStudents = new SortedDictionary<string, double>();
        static BitArray pass = new BitArray(100); // Assume max 100 students
        static ObservableCollection<string> gradeChanges = new ObservableCollection<string>();

        static void Main()
        {
            gradeChanges.CollectionChanged += OnGradeChanged;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("🎓 Mini Student Score Manager");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. Show Students and Grades");
                Console.WriteLine("4. Show Passed Students");
                Console.WriteLine("5. Exit");
                Console.Write("👉 Choose: ");

                switch (Console.ReadLine())
                {
                    case "1": AddStudent(); break;
                    case "2": AddGrade(); break;
                    case "3": ShowAll(); break;
                    case "4": ShowPassed(); break;
                    case "5": return;
                    default: Console.WriteLine("❌ Invalid"); break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            if (namesSet.Contains(name))
            {
                Console.WriteLine("⚠️ Student already exists!");
                return;
            }

            int id = students.Count + 1;
            students.Add(new Student(id, name));
            namesSet.Add(name);
            Console.WriteLine("✅ Student added.");
        }

        static void AddGrade()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id) && id <= students.Count)
            {
                Console.Write("Enter grade: ");
                if (double.TryParse(Console.ReadLine(), out double grade))
                {
                    grades[id] = grade;
                    topStudents[students[id - 1].Name] = grade;
                    pass[id] = grade >= 50;
                    gradeChanges.Add($"Student {id} updated grade to {grade}");
                    Console.WriteLine("✅ Grade saved.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid ID.");
            }
        }

        static void ShowAll()
        {
            Console.WriteLine("📋 Students and Grades:");
            foreach (var student in students)
            {
                string gradeInfo = grades.ContainsKey(student.Id) ? grades[student.Id].ToString() : "N/A";
                Console.WriteLine($"{student} - Grade: {gradeInfo}");
            }
        }

        static void ShowPassed()
        {
            Console.WriteLine(" Passed Students:");
            foreach (var student in students)
            {
                if (pass[student.Id])
                    Console.WriteLine($"{student.Name} ✅");
            }
        }

        static void OnGradeChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"📢 Grade change detected: {e.NewItems[0]}");
        }
    }

}
