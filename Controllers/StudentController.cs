using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI_ASPNet.Data;
using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public StudentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await _dataContext.Students.ToListAsync();
            return Ok(students);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _dataContext.Students.FindAsync(id);
            if (student is null)
            {
                return NotFound($"Student not found with id={id}");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            _dataContext.Students.Add(student);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Students.ToListAsync());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var student = await _dataContext.Students.FindAsync(id);
            if (student is null)
            {
                return NotFound($"Not found student with id={id}");
            }

            _dataContext.Students.Remove(student);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student student)
        {
            var fetchedStudent = await _dataContext.Students.FindAsync(student.Id);
            if (fetchedStudent is null)
            {
                return NotFound($"Not found student with id={student.Id}");
            }

            fetchedStudent.Name = student.Name;
            fetchedStudent.Email = student.Email;
            fetchedStudent.IsMale = student.IsMale;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Students.ToListAsync());
        }

    }
}
