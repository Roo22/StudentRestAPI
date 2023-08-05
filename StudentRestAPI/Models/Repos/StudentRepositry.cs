using Microsoft.EntityFrameworkCore;

namespace StudentRestAPI.Models.Repos
{
    public class StudentRepositry : IStudentRepositry
    {
        private readonly AppDbContext appDbContext;

        public StudentRepositry(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await appDbContext.Students.AddAsync(student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int Studentid)
        {
            var result = await GetStudent(Studentid);
            if (result != null)
            {
                appDbContext.Students.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }

        public async Task<Student> GetStudent(int Studentid)
        {
            return await appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentID == Studentid);

        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await appDbContext.Students
                            .FirstOrDefaultAsync(e => e.Email== email);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await appDbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = appDbContext.Students;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e=> e.FirstName.Contains(name)
                || e.LastName.Contains(name));
            }
            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await GetStudent(student.StudentID);
            if(result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Gender = student.Gender;
                result.Email = student.Email;
                result.PhotoPath = student.PhotoPath;
                if(student.DepartmentID != 0)
                {
                    result.StudentID = student.DepartmentID;
                }
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
