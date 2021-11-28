using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsToDo
{
    public class TodoActivity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? Date { get; set; }

        public string Notes { get; set; }

        public bool Completed { get; set; }
    }
}
