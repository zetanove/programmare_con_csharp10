using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Business
{
    public class DbActivityService : ITodoActivityService
    {
        private readonly ApplicationDbContext _context;
        public DbActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TodoActivity> GetActivities()
        {
            return _context.Activities.ToList();
        }

        public bool SaveActivity(TodoActivity act)
        {
            _context.Activities.Add(act);
            _context.SaveChanges();
            return true;
        }
    }
}
