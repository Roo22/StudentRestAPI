using Microsoft.AspNetCore.Mvc;
using StudentRestAPI.Models;
using StudentRestAPI.Models.Repos;
using System.Diagnostics.Contracts;

namespace StudentRestAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepositry studentRepositry;

        public StudentController(IStudentRepositry studentRepositry)
        {
            this.studentRepositry = studentRepositry;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await studentRepositry.Search(name,gender);
                if (result.Any())
                { 
                    return Ok(result); 
                }
                return NotFound();
            }
            catch(Exception )
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Error From database");
            }
        }

        [HttpGet("Students")]
        public async Task<ActionResult> GetStudents()
        {
            try
            { 
                return Ok(await studentRepositry.GetStudents());

            }
            catch(Exception) {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Error From database");

            }
        }

        [HttpGet("GetStudent/{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await studentRepositry.GetStudent(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
             catch(Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Error From database");
            }
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
              if(student == null)
                {
                    return BadRequest();
                }
                var Email = await studentRepositry.GetStudentByEmail(student.Email);
                if(Email != null)
                {
                    ModelState.AddModelError("Email", "Student Email already exists");
                    return BadRequest(ModelState);
                }
                var CreatedStudent = await studentRepositry.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent),
                    new {id = CreatedStudent.StudentID},CreatedStudent);

            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Error Creating New Student");
            }
        }

        [HttpPut("UpdateStudent/{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(Student student, int id)
        {
            try
            {
                if(id != student.StudentID)
                {
                    return BadRequest("Student ID Mismatched");
                }
                var UpdatedStudent = await studentRepositry.GetStudent(id); 

                if(UpdatedStudent == null)
                {
                    return NotFound($"Student with Id = {id} not found");
                }
                return await studentRepositry.UpdateStudent(student);
            
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Error Updating Student");
            }
        }
        [HttpDelete("DeleteStudent/{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var DeletedStudent = await studentRepositry.GetStudent(id);
                if(DeletedStudent == null)
                {
                    return NotFound($"Student with Id = {id} not found");
                }
                await studentRepositry.DeleteStudent(id);
                return Ok($"Student with Id = {id} deleted");

            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Error Deleting Student");
            }
        }
    }

}
