using ITIProject.Data;
using ITIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student student);
        public void Update(int id, Student student);
        public void DeleteById(int id);
        public List<Student> Getstd(int id);
        public List<Student> GetDept(int id);
    }
   
}
