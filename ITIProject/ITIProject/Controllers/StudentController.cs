using ITIProject.Data;
using ITIProject.Models;
using ITIProject.Repository;
using ITIProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Controllers
{
    public class StudentController : Controller
    {
        //ITIContext _context = new ITIContext();
        IStudentRepo studentRepo;
        IDepartmentRepo departmentRepo;
        ICourseRepo courseRepo;
        public StudentController(IStudentRepo studentRepo,IDepartmentRepo departmentRepo, ICourseRepo courseRepo)
        {
            this.studentRepo = studentRepo;
            this.departmentRepo = departmentRepo;
            this.courseRepo = courseRepo;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = new SelectList(departmentRepo.GetAll(), "DeptId", "DeptName");
            ViewBag.Courses = new SelectList(courseRepo.GetAll(), "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Add(std);
                return RedirectToAction("Index");
            }
            ViewBag.depts = new SelectList(departmentRepo.GetAll(), "DeptId", "DeptName");
            ViewBag.Courses = new SelectList(courseRepo.GetAll(), "CourseId", "CourseName");

            return View(std);
        }
        public IActionResult Details(int id)
        {
            DetailsVM model = new DetailsVM()
            {
                Students = studentRepo.Getstd(id),
                Department = departmentRepo.GetById(id)
            };

            return View(model);
        }

        public IActionResult Index()
        {
            var res = studentRepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var std =studentRepo.GetById(id);
            return View(std);

        }
        [HttpPost, ActionName("Remove")]
        public IActionResult RemoveConfirmed(int id)
        {
            
            studentRepo.DeleteById(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var std = studentRepo.GetById(id);
            ViewBag.Courses = new SelectList(courseRepo.GetAll(), "CourseId", "CourseName");
            ViewBag.depts = new SelectList(departmentRepo.GetAll(), "DeptId", "DeptName");

            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(int id, Student std)
        {
            var oldstd = studentRepo.GetById(id);
            if (oldstd != null)
            {
                studentRepo.Update(id,std);
                return RedirectToAction("Index");
            }
            ViewBag.depts = new SelectList(departmentRepo.GetAll(), "DeptId", "DeptName");
            ViewBag.Courses = new SelectList(courseRepo.GetAll(), "CourseId", "CourseName");

            return View(oldstd);
        }
        //public JsonResult VerifyEmail(string email)
        //{
        //    var emails = _context.Students.Where(x => x.Email == email).ToList();

        //    bool emailExists = emails.Any();

        //    if (emailExists)
        //    {
        //        return Json($"Email {email} is already in use.");
        //    }

        //    return Json(true);
        //}
    }
}
