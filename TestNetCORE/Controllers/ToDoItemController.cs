using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestNetCORE.Models;
using TestNetCORE.ViewModels;
using ToDoItem = TestNetCORE.Models.ToDoItem;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestNetCORE.Controllers
{
    [Authorize]
    public class ToDoItemController : Controller
    {
        private readonly IToDoItemRepository _taskRepository;

        public ToDoItemController(IToDoItemRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            var tasks = _taskRepository.GetAllTasks(User.FindFirstValue(ClaimTypes.NameIdentifier)).OrderBy(t => t.StartDateTime);
      

            var toDoItemViewModel = new ToDoItemViewModel()
            {
                Title = "Here is the list of your tasks",
                Tasks = tasks.ToList()
            };

            return View(toDoItemViewModel);
        }

        public IActionResult AddToDoItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToDoItem(ToDoItem task)
        {
            if (ModelState.IsValid)
            {
                task.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _taskRepository.AddTask(task);

                return RedirectToAction("TaskAdded");
            }

            return View(task);
        }

        public IActionResult ToDoItemComplete(int id)
        {
            var task = _taskRepository.GeTaskById(id);
            if (task == null) return NotFound();

            task.CompletedDateTime = DateTime.UtcNow;
            _taskRepository.UpdateTask(task);

            return View(task);
        }

        [HttpPost]
        public IActionResult ToDoItemCheck(int id, bool checkState)
        {
            var task = _taskRepository.GeTaskById(id);
            if (task == null) return NotFound();

            task.IsChecked = checkState;

            return RedirectToAction("Index");
        }

        public IActionResult ToDoItemDetails(int id)
        {
            var task = _taskRepository.GeTaskById(id);
            if (task == null) return NotFound();

            return View(task);
        }


        public IActionResult TaskAdded()
        {
            return View();
        }

    }
}
