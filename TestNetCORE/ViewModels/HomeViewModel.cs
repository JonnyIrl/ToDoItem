using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItem = TestNetCORE.Models.ToDoItem;

namespace TestNetCORE.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<ToDoItem> Tasks { get; set; }
    }
}
