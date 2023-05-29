using Microsoft.EntityFrameworkCore;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class TaskRepository
    {
        public async void AddAsync(Models.Task task)
        {
            TodoDbContext db = new TodoDbContext();
            db.Add(task);
            await db.SaveChangesAsync();
        }

        public async void UpdateAsync(Models.Task task)
        {
            TodoDbContext db = new TodoDbContext();
            var data = db.Tasks.Where(x => x.Id == task.Id);
            task.Content = task.Content;
            await db.SaveChangesAsync();
        }

        public async void DeleteAsync(int id)
        {
            TodoDbContext db = new TodoDbContext();
            var data = db.Tasks.Find(id);
            db.Tasks.Remove(data);
            await db.SaveChangesAsync();
        }

        public async void MakeActiveAsync(int id)
        {
            TodoDbContext db = new TodoDbContext();
            var data = db.Tasks.Find(id);
            data.Status = true;
            await db.SaveChangesAsync();
        }

        public async void MakeCompletedAsync(int id)
        {
            TodoDbContext db = new TodoDbContext();
            var data = db.Tasks.Find(id);
            data.Status = false;
            await db.SaveChangesAsync();
        }

        public async Task<TasksDto> GetTask(int id)
        {
            TodoDbContext db = new TodoDbContext();
            TasksDto? data = await (from t in db.Tasks
                                         where t.Id == id
                                         select new TasksDto
                                         {
                                             Id = t.Id,
                                             Content = t.Content,
                                             Status = t.Status
                                         }).FirstOrDefaultAsync();
            return data;
        }

        public IQueryable<ActiveTasksDto> GetActiveTasks()
        {
            TodoDbContext db = new TodoDbContext();
            IQueryable<ActiveTasksDto> data = (from t in db.Tasks
                                               where t.Status == true
                                               select new ActiveTasksDto
                                               {
                                                   Id = t.Id,
                                                   Content = t.Content,
                                                   Status = t.Status
                                               });
            return data;
        }

        public IQueryable<CompletedTasksDto> GetCompletedTasks()
        {
            TodoDbContext db = new TodoDbContext();
            IQueryable<CompletedTasksDto> data = (from t in db.Tasks
                                                  where t.Status == false
                                                  select new CompletedTasksDto
                                                  {
                                                      Id = t.Id,
                                                      Content = t.Content,
                                                      Status = t.Status
                                                  });
            return data;
        }

    }
}
