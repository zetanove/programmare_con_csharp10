using System.ComponentModel.DataAnnotations;

namespace TodoWebApplicationMVC.Models
{
	public class TodoActivity
	{
        public TodoActivity()
        {
			Id = Guid.Empty;
        }

        public TodoActivity(string title)
        {
			Id = Guid.NewGuid();
            this.Title = title;
        }

        public Guid Id { get; set; }
		[Required]
		public string Title { get; set; }
		public DateTime? Date { get; set; }
		public string? Notes { get; set; }
		public bool Completed { get; set; }
	}

}
