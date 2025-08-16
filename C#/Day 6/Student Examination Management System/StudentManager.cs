using Student_Examination_Management_System;

public class StudentManager
{
    private Student[] students = new Student[100];
    private int count = 0;

    public void AddStudent(Student s)
    {
        if (count < students.Length)
            students[count++] = s;
    }

    public void AddStudent(params Student[] newStudents)
    {
        foreach (var s in newStudents)
            AddStudent(s);
    }

    public void AddScoreToStudent(int id, string subject, int score)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentID == id)
            {
                students[i].AddScore(subject, score);
                return;
            }
        }
        Console.WriteLine("❌ Student not found.");
    }

    public Student SearchByName(string name)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].FullName.Contains(name))
                return students[i];
        }
        return null;
    }

    public void ListAllStudents()
    {
        for (int i = 0; i < count; i++)
            Console.WriteLine($"{students[i].StudentID} - {students[i].FullName} - {students[i].Major}");
    }

    public void ListActiveStudents()
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].IsActive)
                Console.WriteLine($"{students[i].StudentID} - {students[i].FullName}");
        }
    }

    public Student GetTopScoringStudent()
    {
        double maxAvg = -1;
        Student topStudent = null;

        for (int i = 0; i < count; i++)
        {
            double avg = students[i].GetAverageScore();
            if (avg > maxAvg)
            {
                maxAvg = avg;
                topStudent = students[i];
            }
        }

        return topStudent;
    }

    public double GetAverageScoreByMajor(string major)
    {
        int totalScore = 0;
        int totalSubjects = 0;

        for (int i = 0; i < count; i++)
        {
            if (students[i].Major == major)
            {
                for (int j = 0; j < students[i].SubjectCount; j++)
                {
                    totalScore += students[i].GetScoreAt(j);
                    totalSubjects++;
                }
            }
        }

        return totalSubjects > 0 ? (double)totalScore / totalSubjects : 0;
    }
    public void EditContact(int id, string newEmail, string newPhone, string newAddress)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentID == id)
            {
                students[i].Contact = new StudentContact(newEmail, newPhone, newAddress);
                Console.WriteLine("Contact updated.");
                return;
            }
        }
        Console.WriteLine(" Student not found.");
    }
    public void RemoveStudentByID(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentID == id)
            {
                for (int j = i; j < count - 1; j++)
                {
                    students[j] = students[j + 1];
                }
                students[--count] = null;
                Console.WriteLine(" Student removed.");
                return;
            }
        }
        Console.WriteLine(" Student not found.");
    }
}
