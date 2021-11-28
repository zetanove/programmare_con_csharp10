using TodoWebApplicationMVC.Data;
using TodoWebApplicationMVC.Models;

namespace TodoWebApplicationMVC.Business;

public class DbActivityService : ITodoActivityService
{
    private readonly ApplicationDbContext _context;
    public DbActivityService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<TodoActivity> GetActivities()
    {
        return _context.TodoActivity.ToList();
    }

    public bool SaveActivity(TodoActivity act)
    {
        if (act.Id == Guid.Empty)
        { _context.TodoActivity.Add(act); }
        else _context.Update(act);

        _context.SaveChanges();
        return true;
    }


}


