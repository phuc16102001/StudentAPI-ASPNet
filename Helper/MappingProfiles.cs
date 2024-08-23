using AutoMapper;
using StudentAPI_ASPNet.Dto;
using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<ClassroomDto, Classroom>();
            CreateMap<Classroom, ClassroomDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
        }
    }
}
