namespace StudentAPI_ASPNet.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
