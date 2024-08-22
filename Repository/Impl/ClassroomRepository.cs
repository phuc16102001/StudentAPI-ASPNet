using StudentAPI_ASPNet.Data;
using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Repository.Impl
{
    public class ClassroomRepository : IClassroomRepository
    {

        private readonly DataContext _context;

        public ClassroomRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddClassroom(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            return Saved();
        }

        public ICollection<Classroom> GetAllClassrooms()
        {
            return _context.Classrooms.ToList();
        }

        public Classroom GetClassroom(int id)
        {
            return _context.Classrooms.Find(id);
        }

        public ICollection<Student> GetStudentsInClassroom(int id)
        {
            return _context.Students.Where(s => s.Classroom.Id == id).ToList();
        }

        private bool Saved()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
