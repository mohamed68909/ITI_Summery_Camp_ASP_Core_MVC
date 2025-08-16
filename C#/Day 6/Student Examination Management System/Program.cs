namespace Student_Examination_Management_System
{
    internal class Program
    {

        //    static void Main(string[] args)
        //    {
        //        StudentManager manager = new StudentManager();

        //        var contact1 = new StudentContact("ali@gmail.com", "01012345678", "Cairo");
        //        var contact2 = new StudentContact("sara@gmail.com", "01087654321", "Alex");

        //        var s1 = new RegularStudent("Ali Hassan", "CS", contact1);
        //        var s2 = new ScholarshipStudent("Sara Nabil", "CS", contact2, 3000);

        //        manager.AddStudent(s1, s2);

        //        manager.AddScoreToStudent(s1.StudentID, "Math", 90);
        //        manager.AddScoreToStudent(s1.StudentID, "Physics", 80);
        //        manager.AddScoreToStudent(s2.StudentID, "Math", 95);
        //        manager.AddScoreToStudent(s2.StudentID, "AI", 100);

        //        manager.ListAllStudents();

        //        Console.WriteLine("\n Sara’s Grades:");
        //        s2.DisplayGrades();

        //        Console.WriteLine($"\n Top Student: {manager.GetTopScoringStudent()?.FullName}");

        //        Console.WriteLine($"\n Average in CS: {manager.GetAverageScoreByMajor("CS")}");
        //    }
        //}

        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("\n📘 Student Examination Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Score to Student");
                Console.WriteLine("3. List All Students");
                Console.WriteLine("4. List Active Students");
                Console.WriteLine("5. Search by Name");
                Console.WriteLine("6. Get Top Scoring Student");
                Console.WriteLine("7. Get Average Score by Major");
                Console.WriteLine("8. Edit Student Contact");
                Console.WriteLine("9. Remove Student by ID");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Full Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Major: ");
                        string major = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();

                        Console.Write("Type (1-Regular, 2-Scholarship, 3-Transfer, 4-Graduate): ");
                        string type = Console.ReadLine();

                        StudentContact contact = new StudentContact(email, phone, address);
                        Student student = null;

                        switch (type)
                        {
                            case "1":
                                student = new RegularStudent(name, major, contact);
                                break;
                            case "2":
                                Console.Write("Scholarship Amount: ");
                                double amount = double.Parse(Console.ReadLine());
                                student = new ScholarshipStudent(name, major, contact, amount);
                                break;
                            case "3":
                                Console.Write("Previous University: ");
                                string prevUni = Console.ReadLine();
                                student = new TransferStudent(name, major, contact, prevUni);
                                break;
                            case "4":
                                Console.Write("Thesis Title: ");
                                string thesis = Console.ReadLine();
                                Console.Write("Advisor Name: ");
                                string advisor = Console.ReadLine();
                                student = new GraduateStudent(name, major, contact, thesis, advisor);
                                break;
                            default:
                                Console.WriteLine("❌ Invalid type.");
                                continue;
                        }
                        manager.AddStudent(student);
                        Console.WriteLine("✅ Student added successfully.");
                        break;

                    case "2":
                        Console.Write("Student ID: ");
                        int sid = int.Parse(Console.ReadLine());
                        Console.Write("Subject: ");
                        string sub = Console.ReadLine();
                        Console.Write("Score: ");
                        int sc = int.Parse(Console.ReadLine());
                        manager.AddScoreToStudent(sid, sub, sc);
                        break;

                    case "3":
                        manager.ListAllStudents();
                        break;

                    case "4":
                        manager.ListActiveStudents();
                        break;

                    case "5":
                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();
                        var found = manager.SearchByName(searchName);
                        if (found != null)
                            found.DisplayGrades();
                        else
                            Console.WriteLine(" No student found.");
                        break;

                    case "6":
                        var top = manager.GetTopScoringStudent();
                        if (top != null)
                            top.DisplayGrades();
                        else
                            Console.WriteLine(" No students available.");
                        break;

                    case "7":
                        Console.Write("Enter Major: ");
                        string mj = Console.ReadLine();
                        double avg = manager.GetAverageScoreByMajor(mj);
                        Console.WriteLine($"Average score for {mj}: {avg:F2}");
                        break;

                    case "8":
                        Console.Write("Student ID: ");
                        int cid = int.Parse(Console.ReadLine());
                        Console.Write("New Email: ");
                        string nemail = Console.ReadLine();
                        Console.Write("New Phone: ");
                        string nphone = Console.ReadLine();
                        Console.Write("New Address: ");
                        string naddr = Console.ReadLine();
                        manager.EditContact(cid, nemail, nphone, naddr);
                        break;

                    case "9":
                        Console.Write("Student ID to remove: ");
                        int rid = int.Parse(Console.ReadLine());
                        manager.RemoveStudentByID(rid);
                        break;

                    case "0":
                        Console.WriteLine(" Exiting program.");
                        return;

                    default:
                        Console.WriteLine(" Invalid choice.");
                        break;
                }
            }
        }
    }
}

