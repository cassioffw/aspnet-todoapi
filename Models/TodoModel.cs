namespace Todo.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public String Title { get; set; }

        public bool Done { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}