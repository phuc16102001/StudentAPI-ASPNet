using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StudentAPI_ASPNet.Data;
using StudentAPI_ASPNet.Dto;
using StudentAPI_ASPNet.Entities;
using StudentAPI_ASPNet.Repository;

namespace StudentAPI_ASPNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IClassroomRepository classroomRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            var studentsDto = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentsDto);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student is null)
            {
                return NotFound($"Student not found with id={id}");
            }
            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentDto studentDto, [FromQuery] int classroomId)
        {
            var student = _mapper.Map<Student>(studentDto);

            var classroom = _classroomRepository.GetClassroom(classroomId);
            if (classroom is null)
            {
                return NotFound($"Classroom not found with id={classroomId}");
            }
            student.Classroom = classroom;
            _studentRepository.AddStudent(student, classroomId);
            return Created();
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student is null)
            {
                return NotFound($"Not found student with id={id}");
            }
            _studentRepository.RemoveStudent(student);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStudent([FromBody] StudentDto studentDto, [FromQuery] int classroomId)
        {
            var student = _mapper.Map<Student>(studentDto);
            var fetchedStudent = _studentRepository.GetStudent(student.Id);
            if (fetchedStudent is null)
            {
                return NotFound($"Student not found with id={student.Id}");
            }

            var classroom = _classroomRepository.GetClassroom(classroomId);
            if (classroom is null)
            {
                return NotFound($"Classroom not found with id={classroomId}");
            }

            fetchedStudent.Classroom = classroom;
            fetchedStudent.Name = student.Name;
            fetchedStudent.IsMale = student.IsMale;
            fetchedStudent.Email = student.Email;

            _studentRepository.UpdateStudent(fetchedStudent);
            return Ok();
        }

    }
}
