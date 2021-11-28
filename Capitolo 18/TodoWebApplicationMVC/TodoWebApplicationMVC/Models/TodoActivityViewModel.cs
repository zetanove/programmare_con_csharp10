namespace TodoWebApplicationMVC.Models
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
