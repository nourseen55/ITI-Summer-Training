using ITIProject.Data;
using ITIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Repository
{
    public class StudentRepo : IStudentRepo
    {
        ITIContext context;
        public StudentRepo(ITIContext iTIContext)
        {
            context = iTIContext;

        }
        public void Add(Student student)
        {
            context.Add(student);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var std = context.Students.FirstOrDefault(a => a.Id == id);
            context.Students.Remove(std);
            context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return context.Students.Include(s => s.Department).Include(s => s.Course).ToList();

        }

        public Student GetById(int id)
        {
            return context.Students.SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id, Student std)
        {
            var oldstd = GetById(id);
            oldstd.Name = std.Name;
            oldstd.Age = std.Age;
            oldstd.DeptId = std.DeptId;
            context.Update(oldstd);
            context.SaveChanges();
        }
        public List<Student> Getstd(int id)
        {
            return context.Students.Where(x => x.Id == id).ToList();

        }
        public List<Student> GetDept(int id)
        {
            return context.Students.Where(x => x.DeptId == id).ToList();

        }
    }
}
