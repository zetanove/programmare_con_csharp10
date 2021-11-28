using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Business
{
    public class TestActivityService : ITodoActivityService
    {
        public List<TodoActivity> GetActivities()
        {
            List<TodoActivity> list = new List<TodoActivity>();
            list.Add(new TodoActivity("Test 1") { });
            list.Add(new TodoActivity("Test 2") { Date = new DateTime(2020, 01, 26), Completed = true });
            list.Add(new TodoActivity("Test 3") { Date = DateTime.Now });
            return list; 
        }
       
    }
}
