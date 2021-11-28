using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class TodoActivityViewModel
    {
        public List<TodoActivity> Activities { get; set; }

        public TodoActivityViewModel()
        {
            Activities = new List<TodoActivity>();
        }
    }
}
