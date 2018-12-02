using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace TestNetCORE.Models
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ToDoItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ToDoItem> GetAllTasks(string userId)
        {
            return _appDbContext.ToDoItems.Where(x => x.UserId == userId);
        }

        public bool AddTask(ToDoItem task)
        {
            task = UpdateLastModifiedDateTime(task);
            _appDbContext.ToDoItems.Add(task);
            _appDbContext.SaveChanges();
            return true;
        }

        public ToDoItem GeTaskById(int taskId)
        {
            return _appDbContext.ToDoItems.FirstOrDefault(t => t.Id == taskId);
        }

        public ToDoItem UpdateTask(ToDoItem task)
        {
            ToDoItem existingTask = GeTaskById(task.Id);
            if (existingTask == null) return null;

            task = UpdateLastModifiedDateTime(task);
            _appDbContext.ToDoItems.Update(task);
            _appDbContext.SaveChanges();

            return GeTaskById(task.Id);
        }

        public bool RemoveTask(ToDoItem task)
        {
            return RemoveTaskById(task.Id);
        }

        public bool RemoveTaskById(int taskId)
        {
            ToDoItem task = GeTaskById(taskId);
            if (task == null) return false;

            ToDoItem updatedTask = UpdateTask(task);

            return updatedTask != null;
        }

        public bool CompleteTask(ToDoItem task)
        {
            return CompleteTaskById(task.Id);
        }

        public bool CompleteTaskById(int taskId)
        {
            ToDoItem existingTask = GeTaskById(taskId);
            if (existingTask == null) return false;

            existingTask.CompletedDateTime = DateTime.UtcNow;
            ToDoItem updatedTask = UpdateTask(existingTask);

            return updatedTask != null;
        }

        private ToDoItem UpdateLastModifiedDateTime(ToDoItem task)
        {
            task.LastTimeModified = DateTime.UtcNow;
            return task;
        }
    }
}
