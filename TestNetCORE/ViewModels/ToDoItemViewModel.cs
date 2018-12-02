using System;
using System.Collections.Generic;
using System.Linq;
using ToDoItem = TestNetCORE.Models.ToDoItem;

namespace TestNetCORE.ViewModels
{
    public class ToDoItemViewModel
    {
        public string Title { get; set; }
        public List<ToDoItem> Tasks { get; set; }
    }
}
