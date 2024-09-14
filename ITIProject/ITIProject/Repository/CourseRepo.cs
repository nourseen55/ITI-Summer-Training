using ITIProject.Data;
using ITIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Repository
{
    public class CourseRepo:ICourseRepo
    {
        ITIContext context;
        public CourseRepo(ITIContext iTIContext)
        {
            context = iTIContext;
            
        }
        public void Add(Course course)
        {
            context.Add(course);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var oldcrs = context.Courses.FirstOrDefault(a => a.CourseId == id);
            context.Courses.Remove(oldcrs);
            context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return context.Courses.Include(s => s.Students).ToList();

        }

        public Course GetById(int id)
        {
            return context.Courses.Include(x=>x.Students).SingleOrDefault(x => x.CourseId == id);
        }

        public void Update(int id, Course crs)
        {
            var oldcrs = GetById(id);
            oldcrs.CourseName = crs.CourseName;
            oldcrs.Hours = crs.Hours;
            oldcrs.Students = crs.Students;
            context.Update(oldcrs);
            context.SaveChanges();
        }
        public List<Course> GetCourse(int id)
        {
            return context.Courses.Where(x => x.CourseId == id).ToList();

        }
       
    }
}
