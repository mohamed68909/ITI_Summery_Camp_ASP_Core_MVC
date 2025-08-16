using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Examination_Management_System
{
    public class GraduateStudent : Student
    {
        public string ThesisTitle { get; set; }
        public string AdvisorName { get; set; }

        public GraduateStudent(string fullName, string major, StudentContact contact, string thesis, string advisor)
            : base(fullName, major, contact)
        {
            ThesisTitle = thesis;
            AdvisorName = advisor;
        }

        public override void DisplayGrades()
        {
            Console.WriteLine($"📗 Graduate: {FullName}, Thesis: {ThesisTitle}, Advisor: {AdvisorName}");
            for (int i = 0; i < subjectCount; i++)
                Console.WriteLine($"- {subjects[i]}: {scores[i]}");
        }
    }

}
