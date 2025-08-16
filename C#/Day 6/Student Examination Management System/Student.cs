using Student_Examination_Management_System;

public abstract class Student : IAssessable
{
    private static int _idCounter = 1;
    public static int TotalStudents = 0;

    public int StudentID { get; }
    public string FullName { get; set; }
    public string Major { get; set; }
    public StudentContact Contact;
    public bool IsActive { get; set; }

    protected string[] subjects = new string[10];
    protected int[] scores = new int[10];
    protected int subjectCount = 0;

    public Student()
    {
        StudentID = _idCounter++;
        TotalStudents++;
        IsActive = true;
    }

    public Student(string fullName, string major, StudentContact contact) : this()
    {
        FullName = fullName;
        Major = major;
        Contact = contact;
    }

    public virtual void AddScore(string subject, int score)
    {
        if (subjectCount >= 10)
        {
            Console.WriteLine("❌ Cannot add more than 10 subjects.");
            return;
        }
        subjects[subjectCount] = subject;
        scores[subjectCount] = score;
        subjectCount++;
    }

    public int SubjectCount => subjectCount;

    public string GetSubjectAt(int index)
    {
        if (index >= 0 && index < subjectCount)
            return subjects[index];
        return "";
    }

    public int GetScoreAt(int index)
    {
        if (index >= 0 && index < subjectCount)
            return scores[index];
        return -1;
    }

    public double GetAverageScore()
    {
        if (subjectCount == 0) return 0;
        int sum = 0;
        for (int i = 0; i < subjectCount; i++)
            sum += scores[i];
        return (double)sum / subjectCount;
    }

    public abstract void DisplayGrades();
}
