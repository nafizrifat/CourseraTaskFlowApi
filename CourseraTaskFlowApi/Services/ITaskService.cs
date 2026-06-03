using CourseraTaskFlowApi.Models;

namespace CourseraTaskFlowApi.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTasks();
        TaskItem? GetTaskById(int id);
        TaskItem CreateTask(TaskItem task);
        bool UpdateTask(int id, TaskItem updatedTask);
        bool DeleteTask(int id);
    }
}
