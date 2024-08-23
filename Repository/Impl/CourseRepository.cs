using StudentAPI_ASPNet.Data;
using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Repository.Impl
{
    public class CourseRepository : ICourseRepository
    {

        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddCourse(Course course)
        {
            _context.Courses.Add(course);
            return Saved();
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.Find(id);
        }

        public ICollection<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        private bool Saved()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            return Saved();
        }

        public ICollection<Student> GetStudentEnrolledCourse(int id)
        {
            return _context.StudentCourses.Where(sc => sc.CourseId == id).Select(sc => sc.Student).ToList();
        }
    }
}
