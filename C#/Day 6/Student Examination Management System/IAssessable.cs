namespace Student_Examination_Management_System
{
    public interface IAssessable
    {
        void AddScore(string subject, int score);
        void DisplayGrades();
    }

}