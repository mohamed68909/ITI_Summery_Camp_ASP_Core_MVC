using System;
using System.Collections.Generic;

namespace CompanyHRPayroll
{
    
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Person(int id, string fullName)
        {
            if (id <= 0) throw new ArgumentException("ID must be > 0");
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Name must not be empty");
            Id = id;
            FullName = fullName;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {FullName}");
        }

        public void DisplayInfo(bool showId)
        {
            if (showId)
                Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {FullName}");
        }
    }

    
    public class Employee : Person
    {
        public double BaseSalary { get; set; }
        public DateTime HireDate { get; set; }

        public static int TotalEmployees { get;  set; } = 0;
        public static double TotalPayroll { get;  set; } = 0;

        public Employee(int id, string fullName, double baseSalary, DateTime hireDate)
            : base(id, fullName)
        {
            BaseSalary = baseSalary;
            HireDate = hireDate;

            TotalEmployees++;
            TotalPayroll += baseSalary;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Salary: {BaseSalary}");
            Console.WriteLine($"Hire Date: {HireDate.ToShortDateString()}");
        }
    }

    
    public class Manager : Employee
    {
        public double Bonus { get; set; }
        public List<Employee> TeamMembers { get; set; }

        public Manager(int id, string fullName, double baseSalary, DateTime hireDate, double bonus)
            : base(id, fullName, baseSalary, hireDate)
        {
            Bonus = bonus;
            TeamMembers = new List<Employee>();
            TotalPayroll += bonus;
        }

        public double GetTotalSalary()
        {
            return BaseSalary + Bonus;
        }

        public void AddTeamMember(Employee e)
        {
            if (e != null)
                TeamMembers.Add(e);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n[Manager Info]");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {FullName}");
            Console.WriteLine($"Salary: {BaseSalary}");
            Console.WriteLine($"Bonus: {Bonus}");
            Console.WriteLine($"Total Salary: {GetTotalSalary()}");
            Console.WriteLine($"Team Size: {TeamMembers.Count}");
        }

        public static Manager operator +(Manager m1, Manager m2)
        {
            // Create a new manager merging salaries and teams
            Manager merged = new Manager(
                Math.Max(m1.Id, m2.Id) + 1,
                m1.FullName + " & " + m2.FullName,
                m1.BaseSalary + m2.BaseSalary,
                DateTime.Now,
                m1.Bonus + m2.Bonus
            );

            foreach (var member in m1.TeamMembers)
                merged.AddTeamMember(member);
            foreach (var member in m2.TeamMembers)
                merged.AddTeamMember(member);

            return merged;
        }
    }

   
    class Program
    {
        static void Main()
        {
            Employee emp1 = new Employee(1, "Ali Hassan", 8000, new DateTime(2022, 1, 10));
            Manager mgr1 = new Manager(2, "Sarah Ahmed", 12000, new DateTime(2020, 3, 15), 3000);
            Employee emp2 = new Employee(3, "Mona Khaled", 7000, new DateTime(2021, 5, 5));
            Employee emp3 = new Employee(4, "Tariq Zaki", 8000, new DateTime(2023, 2, 20));

            mgr1.AddTeamMember(emp2);
            mgr1.AddTeamMember(emp3);

            Console.WriteLine($"Total Employees: {Employee.TotalEmployees}");
            Console.WriteLine($"Total Payroll: {Employee.TotalPayroll}");

            mgr1.DisplayInfo();

            Manager mgr2 = new Manager(5, "Omar Samir", 9000, new DateTime(2019, 1, 10), 3000);
            mgr2.AddTeamMember(emp1);

            Manager merged = mgr1 + mgr2;
            Console.WriteLine("\n[After Operator Overloading]");
            Console.WriteLine($"MergedManager created with total salary: {merged.GetTotalSalary()}");
            Console.WriteLine($"Team Size: {merged.TeamMembers.Count}");
        }
    }
}
