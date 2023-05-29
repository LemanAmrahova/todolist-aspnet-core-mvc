namespace TodoList.DTOs
{
    public class ActiveTasksDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
        public List<ActiveTasksDto>? aList { get; set; }
    }
}
