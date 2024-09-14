using ITIProject.Data;
using ITIProject.Models;
using ITIProject.Repository;
using ITIProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepo departmentRepo ;
        IStudentRepo studentRepo ;
        public DepartmentController(IDepartmentRepo departmentRepo,IStudentRepo studentRepo)
        {
            this.departmentRepo = departmentRepo ;
            this.studentRepo = studentRepo ;
            
        }
        public IActionResult Index()
        {
            var depts = departmentRepo.GetAll();
            return View(depts);
        }
        public IActionResult Details(int id)
        {
            DetailsVM model = new DetailsVM()
            {
                Students = studentRepo.GetDept(id),
                Department = departmentRepo.GetById(id)
            };

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            departmentRepo.Add(department);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = departmentRepo.GetById(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            departmentRepo.Update(department);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var std = departmentRepo.GetById(id);
            return View(std);

        }
        [HttpPost, ActionName("Remove")]
        public IActionResult RemoveConfirmed(int id)
        {

            departmentRepo.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
