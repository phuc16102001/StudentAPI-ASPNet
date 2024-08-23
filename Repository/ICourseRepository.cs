using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Repository
{
    public interface ICourseRepository
    {
        ICollection<Course> GetAllCourses();
        Course GetCourse(int id);
        bool AddCourse(Course course);
        bool UpdateCourse(Course course);
        ICollection<Student> GetStudentEnrolledCourse(int id);
    }
}
