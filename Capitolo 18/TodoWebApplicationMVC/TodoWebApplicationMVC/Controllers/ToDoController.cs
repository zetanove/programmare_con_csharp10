using Microsoft.AspNetCore.Mvc;
using TodoWebApplicationMVC.Business;
using TodoWebApplicationMVC.Data;
using TodoWebApplicationMVC.Models;

namespace TodoWebApplicationMVC.Controllers
{
    public class ToDoController : Controller
    {
        //ApplicationDbContext _context;
        //public ToDoController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        ITodoActivityService _service;
        public ToDoController(ITodoActivityService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            TodoActivityViewModel model = new TodoActivityViewModel();
            model.Activities.AddRange(_service.GetActivities());
            return View(model);
        }

        [HttpGet]
        public IActionResult EditActivity(Guid id)
        {
            var allActivities = _service.GetActivities();
            var act = allActivities.SingleOrDefault(a => a.Id == id);
            return View(act);
        }

        [HttpGet]
        public IActionResult NewActivity()
        {
            return View("EditActivity", new TodoActivity("nuova"));
        }

        [HttpPost]
        public IActionResult EditActivity(TodoActivity item)
        {
            _service.SaveActivity(item);
            return RedirectToAction("Index");
        }


    }
}
