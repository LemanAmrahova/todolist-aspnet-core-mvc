using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        TaskRepository taskRepository = new TaskRepository();
        public async Task<IActionResult> Todos()
        {
            AllTaskClassDto tasksDto = new AllTaskClassDto()
            {
                activetask = taskRepository.GetActiveTasks().ToList(),
                completedtask = taskRepository.GetCompletedTasks().ToList()
            };
            return View(tasksDto);
        }


        public async Task<IActionResult> Add(int id)
        {
            if (id != 0)
            {
                AllTaskClassDto tasksDto = new AllTaskClassDto()
                {
                    tasks = await taskRepository.GetTask(id)
                };
                return RedirectToAction("Todos", tasksDto);
            }
            return RedirectToAction("Todos");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AllTaskClassDto? model)
        {
            if (ModelState.IsValid)
            {
                if (model.tasks.Id == 0)
                {
                    Models.Task task = new Models.Task()
                    {
                        Content = model.tasks.Content
                    };
                    taskRepository.AddAsync(task);

                }
                else
                {
                    Models.Task data = new Models.Task()
                    {
                        Id = model.tasks.Id,
                        Content = model.tasks.Content
                    };
                    taskRepository.UpdateAsync(data);
                }
                return RedirectToAction("Todos");
            }
            return RedirectToAction("Todos");
        }

        public async Task<IActionResult> MakeActive(int id)
        {
            taskRepository.MakeActiveAsync(id);
            return RedirectToAction("Todos");
        }

        public async Task<IActionResult> MakeCompleted(int id)
        {
            taskRepository.MakeCompletedAsync(id);
            return RedirectToAction("Todos");
        }

        public async Task<IActionResult> Delete(int id)
        {
            taskRepository.DeleteAsync(id);
            return RedirectToAction("Todos");
        }

    }
}
