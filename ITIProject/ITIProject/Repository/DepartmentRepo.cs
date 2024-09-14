using ITIProject.Data;
using ITIProject.Models;

namespace ITIProject.Repository
{
    public class DepartmentRepo:IDepartmentRepo
    {

            ITIContext context;
            public DepartmentRepo(ITIContext iTIContext)
            {
                context = iTIContext;

            }
        public void Add(Department dept)
            {
                context.Add(dept);
                context.SaveChanges();
            }

            public void DeleteById(int id)
            {
                var dept = context.Departments.FirstOrDefault(a => a.DeptId == id);
                dept.Status = false;
                context.SaveChanges();
            }

            public List<Department> GetAll()
            {
                return context.Departments.Where(x => x.Status == true).ToList();

            }

            public Department GetById(int id)
            {
                return context.Departments.SingleOrDefault(x => x.DeptId == id);
            }

            public void Update(Department dept)
            {
                context.Update(dept);
                context.SaveChanges();
            }

        }
    
}
