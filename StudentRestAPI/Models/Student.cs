namespace StudentRestAPI.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public Gender Gender { get; set;}
        public int DepartmentID { get; set; }
        public string PhotoPath { get; set;}

    }
}
