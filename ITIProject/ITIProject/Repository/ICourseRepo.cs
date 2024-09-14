using ITIProject.Models;

namespace ITIProject.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public void Add(Course Course);
        public void Update(int id, Course Course);
        public void DeleteById(int id);
        public List<Course> GetCourse(int id);
    }
}
