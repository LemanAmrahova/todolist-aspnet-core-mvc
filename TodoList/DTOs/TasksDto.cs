using System.ComponentModel.DataAnnotations;

namespace TodoList.DTOs
{
    public class TasksDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Content is required!")]
        public string? Content { get; set; }
        public bool? Status { get; set; }
    }
}
