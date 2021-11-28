using System;

namespace UWPToDo
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