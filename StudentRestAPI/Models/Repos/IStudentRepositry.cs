namespace StudentRestAPI.Models.Repos
{
    public interface IStudentRepositry
    {
        Task<IEnumerable<Student>> Search( string name, Gender? gender);
        Task<Student> GetStudent(int Studentid);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentByEmail(string email);
        Task<Student> AddStudent (Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int Studentid);

    }
}
