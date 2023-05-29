namespace TodoList.DTOs
{
    public class CompletedTasksDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
        public List<CompletedTasksDto>? cList { get; set; }
    }
}
