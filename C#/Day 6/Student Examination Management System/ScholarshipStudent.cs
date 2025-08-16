using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Examination_Management_System
{
    public class ScholarshipStudent : Student
    {
        public double ScholarshipAmount { get; set; }

        public ScholarshipStudent(string fullName, string major, StudentContact contact, double amount)
            : base(fullName, major, contact)
        {
            ScholarshipAmount = amount;
        }

        public override void DisplayGrades()
        {
            Console.WriteLine($"🎓 Scholarship Student: {FullName}, Amount: ${ScholarshipAmount}");
            for (int i = 0; i < subjectCount; i++)
                Console.WriteLine($"- {subjects[i]}: {scores[i]}");
        }
    }

}
