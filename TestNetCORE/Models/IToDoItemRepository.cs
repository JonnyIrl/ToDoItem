using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCORE.Models
{
    public interface IToDoItemRepository
    {
        bool AddTask(ToDoItem task);
        IEnumerable<ToDoItem> GetAllTasks(string userId);

        ToDoItem GeTaskById(int taskId);

        ToDoItem UpdateTask(ToDoItem task);

        bool RemoveTask(ToDoItem task);

        bool RemoveTaskById(int taskId);

        bool CompleteTask(ToDoItem task);
        bool CompleteTaskById(int taskId);

    }
}
