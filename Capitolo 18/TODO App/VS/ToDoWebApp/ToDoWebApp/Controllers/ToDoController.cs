using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApp.Business;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    //[Authorize]
    public class ToDoController : Controller
    {
        ITodoActivityService _service;
        public ToDoController(ITodoActivityService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            TodoActivityViewModel model = new TodoActivityViewModel();
            var allActivities = _service.GetActivities();
            model.Activities.AddRange(allActivities);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditActivity(Guid id)
        {
            var allActivities = _service.GetActivities();
            var act = allActivities.SingleOrDefault(a => a.Id == id);
            return View(act);
        }

        [HttpPost]
        public IActionResult EditActivity(TodoActivity item)
        {
            _service.SaveActivity(item);
            return RedirectToAction("Index");
        }
    }
}