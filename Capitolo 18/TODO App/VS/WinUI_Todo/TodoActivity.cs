using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Todo
{
    public class TodoActivity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
    }

    public class TodoActivityViewModel
    {
        public List<TodoActivity> Activities { get; set; }

        public TodoActivityViewModel()
        {
            Activities = new List<TodoActivity>();
        }
    }
}
