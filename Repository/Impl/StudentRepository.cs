using StudentAPI_ASPNet.Data;
using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Repository.Impl
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;            
        }

        public bool AddStudent(Student student, int classroomId)
        {
            _context.Students.Add(student);
            return Saved();
        }

        public bool EnrollStudentToCourse(Student student, Course course)
        {
            var studentCourse = new StudentCourse()
            {
                Student = student,
                Course = course
            };
            _context.StudentCourses.Add(studentCourse);
            return Saved();
        }

        public ICollection<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public ICollection<Course> GetEnrolledCourses(int studentId)
        {
            return _context.StudentCourses.Where(sc => sc.StudentId == studentId).Select(sc => sc.Course).ToList();
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public bool RemoveStudent(Student student)
        {
            _context.Students.Remove(student);
            return Saved();
        }

        public bool UnrollStudentFromCourse(Student student, Course course)
        {
            var studentCourse = _context.StudentCourses.Find(student.Id, course.Id);
            _context.Remove(studentCourse);
            return Saved();
        }

        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            return Saved();
        }

        private bool Saved()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
