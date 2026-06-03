using CourseraTaskFlowApi.Models;
using System.Xml.Linq;

namespace CourseraTaskFlowApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        private int _nextId = 1;

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public TaskItem? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskItem CreateTask(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            return task;
        }

        public bool UpdateTask(int id, TaskItem updatedTask)
        {
            TaskItem? existingTask = GetTaskById(id);

            if (existingTask == null)
            {
                return false;
            }

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.IsCompleted = updatedTask.IsCompleted;

            return true;
        }

        public bool DeleteTask(int id)
        {
            TaskItem? task = GetTaskById(id);

            if (task == null)
            {
                return false;
            }

            _tasks.Remove(task);
            return true;
        }
    }
}
