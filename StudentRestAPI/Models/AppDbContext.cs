using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace StudentRestAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>().HasData(
                new Student 
                { 
                    StudentID =1,
                    FirstName = "John",
                    LastName = "Doe",
                    DepartmentID = 1,
                    Gender = Gender.Male,
                    PhotoPath = "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg",
                    Email = "john@john.com"
                },
                 new Student
                 {
                     StudentID = 2,
                     FirstName = "Alex",
                     LastName = "John",
                     DepartmentID = 2,
                     Gender = Gender.Male,
                     PhotoPath = "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg",
                     Email = "alex@alex.com"
                 },
                  new Student
                  {
                      StudentID = 3,
                      FirstName = "Emily",
                      LastName = "Doe",
                      DepartmentID = 3,
                      Gender = Gender.Female,
                      PhotoPath = "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg",
                      Email = "emily@emily.com"
                  },
                   new Student
                   {
                       StudentID = 4,
                       FirstName = "Lizzy",
                       LastName = "Addrison",
                       DepartmentID = 4,
                       Gender = Gender.Female,
                       PhotoPath = "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg",
                       Email = "lizzy@lizzy.com"
                   }
                );
        }
    }
}

