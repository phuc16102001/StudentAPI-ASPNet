using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI_ASPNet.Dto;
using StudentAPI_ASPNet.Entities;
using StudentAPI_ASPNet.Repository;

namespace StudentAPI_ASPNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {

        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public ClassroomController(IClassroomRepository classroomRepository, IMapper mapper) 
        {
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllClassrooms()
        {
            var classrooms = _classroomRepository.GetAllClassrooms();
            var classroomsDto = _mapper.Map<List<ClassroomDto>>(classrooms);
            return Ok(classroomsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAllClassrooms(int id)
        {
            var classroom = _classroomRepository.GetClassroom(id);
            if (classroom is null)
            {
                return NotFound($"Classroom not found with id={id}");
            }
            var classroomDto = _mapper.Map<ClassroomDto>(classroom);
            return Ok(classroomDto);
        }

        [HttpPost]
        public IActionResult AddClassroom(ClassroomDto classroomDto)
        {
            var classroom = _mapper.Map<Classroom>(classroomDto);
            _classroomRepository.AddClassroom(classroom);
            return Created();
        }

        [HttpGet]
        [Route("{id}/students")]
        public IActionResult GetStudentsInClassroom(int id)
        {
            var students = _classroomRepository.GetStudentsInClassroom(id);
            var studentsDto = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentsDto);
        }

    }
}
