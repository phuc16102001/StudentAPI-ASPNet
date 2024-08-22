namespace StudentAPI_ASPNet.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
