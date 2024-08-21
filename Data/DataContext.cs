using Microsoft.EntityFrameworkCore;
using StudentAPI_ASPNet.Entities;

namespace StudentAPI_ASPNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
