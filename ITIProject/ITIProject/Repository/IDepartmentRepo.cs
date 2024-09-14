using ITIProject.Data;
using ITIProject.Models;

namespace ITIProject.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department dept);
        public void Update(Department dept);
        public void DeleteById(int id);
    }
   
}
