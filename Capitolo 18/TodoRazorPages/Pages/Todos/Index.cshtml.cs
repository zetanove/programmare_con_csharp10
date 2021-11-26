using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoRazorPages.Models;

namespace TodoRazorPages.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly TodoRazorPages.Models.TodoDbContext _context;

        public IndexModel(TodoRazorPages.Models.TodoDbContext context)
        {
            _context = context;
        }

        public IList<TodoActivity> TodoActivity { get;set; }

        public async Task OnGetAsync()
        {
            TodoActivity = await _context.Activities.ToListAsync();
        }
    }
}
