using TodoWebApplicationMVC.Models;
namespace TodoWebApplicationMVC.Business;

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

public class TestActivityService : ITodoActivityService
{
    public List<TodoActivity> GetActivities()
    {
        List<TodoActivity> list = new List<TodoActivity>();
        list.Add(new TodoActivity("Test 1") { });
        list.Add(new TodoActivity("Test 2") { Date = new DateTime(2020, 01, 26), Completed = true });
        return list;
    }
}
