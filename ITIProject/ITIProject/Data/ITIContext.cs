using ITIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Data
{
    public class ITIContext : DbContext
    {
      
        public ITIContext()
        {
            
        }
        public ITIContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
