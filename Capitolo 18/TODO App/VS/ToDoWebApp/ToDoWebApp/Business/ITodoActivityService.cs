using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Business
{
    public interface ITodoActivityService
    {
        public List<TodoActivity> GetActivities();

        public List<TodoActivity> GetIncompleteActivities()
        {
            return GetActivities();
        }

        public bool SaveActivity(TodoActivity act)
        {
            return false;
        }

        public bool DeleteActivity(TodoActivity act)
        {
            return false;
        }
    }
}
