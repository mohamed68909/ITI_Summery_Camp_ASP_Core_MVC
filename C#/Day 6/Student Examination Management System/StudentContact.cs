namespace Student_Examination_Management_System
{
    public struct StudentContact
    {
        public string Email;
        public string Phone;
        public string Address;

        public StudentContact(string email, string phone, string address)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }
    }

}