using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Examination_Management_System
{
    public class TransferStudent : Student
    {
        public string PreviousUniversity { get; set; }

        public TransferStudent(string fullName, string major, StudentContact contact, string university)
            : base(fullName, major, contact)
        {
            PreviousUniversity = university;
        }

        public override void DisplayGrades()
        {
            Console.WriteLine($"🔄 Transfer Student: {FullName}, From: {PreviousUniversity}");
            for (int i = 0; i < subjectCount; i++)
                Console.WriteLine($"- {subjects[i]}: {scores[i]}");
        }
    }

}
