using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Repository
{
    public interface IClassroomRepository
    {
        ICollection<Classroom> GetAllClassrooms();
        Classroom GetClassroom(int id);
        bool AddClassroom(Classroom classroom);
        ICollection<Student> GetStudentsInClassroom(int id);
    }
}
