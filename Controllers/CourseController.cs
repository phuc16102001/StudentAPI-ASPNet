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
    public class CourseController : ControllerBase
    {

        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses();
            var coursesDto = _mapper.Map<List<CourseDto>>(courses);
            return Ok(coursesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _courseRepository.GetCourse(id);
            if (course is null)
            {
                return NotFound($"Course not found with id={id}");
            }
            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        [HttpGet]
        [Route("{id}/students")]
        public IActionResult GetStudentEnrolledCourse(int id)
        {
            var course = _courseRepository.GetCourse(id);
            if (course is null)
            {
                return NotFound($"Course not found with id={id}");
            }

            var students = _courseRepository.GetStudentEnrolledCourse(id);
            var studentsDto = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentsDto);
        }


        [HttpPost]
        public IActionResult AddCourse([FromBody] CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _courseRepository.AddCourse(course);
            return Created();
        }

        [HttpPut]
        public IActionResult UpdateCourse([FromBody] CourseDto courseDto)
        {
            var fetchedCourse = _courseRepository.GetCourse(courseDto.Id);
            if (fetchedCourse is null)
            {
                return NotFound($"Course not found with id={courseDto.Id}");
            }

            fetchedCourse.Name = courseDto.Name;
            fetchedCourse.Credit = courseDto.Credit;
            _courseRepository.UpdateCourse(fetchedCourse);
            return Ok();
        }
    }
}
