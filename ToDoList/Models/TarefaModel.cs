namespace ToDoList.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int Status { get; set; }
    }
}
