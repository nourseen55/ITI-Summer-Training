using ITIProject.Models;
using ITIProject.Repository;
using ITIProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITIProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _courseRepo;
        public CourseController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }
        public IActionResult Details(int id)
        {
            var crs= _courseRepo.GetById(id);
            return View(crs);
        }
        public IActionResult Index()
        {
            var res = _courseRepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var std = _courseRepo.GetById(id);
            return View(std);

        }
        [HttpPost, ActionName("Remove")]
        public IActionResult RemoveConfirmed(int id)
        {

            _courseRepo.DeleteById(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var crs = _courseRepo.GetById(id);

            return View(crs);
        }
        [HttpPost]
        public IActionResult Edit(int id, Course std)
        {
            var oldcrs = _courseRepo.GetById(id);
            if (oldcrs != null)
            {
                _courseRepo.Update(id, std);
                return RedirectToAction("Index");
            }

            return View(oldcrs);
        }
    }
}
