using TodoList.Models;

namespace TodoList.DTOs
{
    public class AllTaskClassDto
    {
        public List<ActiveTasksDto>? activetask { get; set; }
        public List<CompletedTasksDto>? completedtask { get; set; }
        public TasksDto? tasks { get; set; }
        public Models.Task? task { get; set; } 
    }
}
