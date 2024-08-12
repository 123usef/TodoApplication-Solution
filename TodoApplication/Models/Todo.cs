namespace TodoApplication.Models
{
    public class Todo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime DeadLine { get; set; }

        public bool isFinished { get; set; }
    }
}
