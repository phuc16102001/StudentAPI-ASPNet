using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Repository
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAllStudents();
        Student GetStudent(int id);
        bool AddStudent(Student student, int classroomId);
        bool RemoveStudent(Student student);
        bool UpdateStudent(Student student);
    }
}
