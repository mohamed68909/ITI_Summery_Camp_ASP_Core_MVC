using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Examination_Management_System
{
    public class RegularStudent : Student
    {
        public RegularStudent(string fullName, string major, StudentContact contact)
            : base(fullName, major, contact) { }

        public override void DisplayGrades()
        {
            Console.WriteLine($" {FullName}'s Grades:");
            for (int i = 0; i < subjectCount; i++)
                Console.WriteLine($"- {subjects[i]}: {scores[i]}");
        }
    }
}
