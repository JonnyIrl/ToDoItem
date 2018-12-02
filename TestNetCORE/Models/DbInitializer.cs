using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCORE.Models
{
    public static class DbInitializer
    {
        //Populate database if there is no data in there already.
        public static void Seed(AppDbContext context)
        {
            if (context.ToDoItems.Any())
            {               
                return;
            }
            context.AddRange(
                new ToDoItem
                {
                    Title = "First Task",
                    Description = "This is the first task that needs to be completed. I am just making this a really long task to see what happens, does the box get bigger, does it overlap the buttons? What exactly happens to a really long task like this.",
                    StartDateTime = DateTime.Parse("30/11/2018 09:00:00"),
                    EndDateTime = DateTime.Parse("30/11/2018 17:00:00"),
                    CompletedDateTime = DateTime.MinValue
                },
                new ToDoItem
                {
                    Title = "Second Task",
                    Description = "This is the second task that needs to be completed.",
                    StartDateTime = DateTime.Parse("01/12/2018 09:00:00"),
                    EndDateTime = DateTime.Parse("01/12/2018 17:00:00"),
                    CompletedDateTime = DateTime.MinValue
                },
                new ToDoItem
                {
                    Title = "Third Task",
                    Description = "This is the third task that needs to be completed.",
                    StartDateTime = DateTime.Parse("02/12/2018 09:00:00"),
                    EndDateTime = DateTime.Parse("02/12/2018 17:00:00"),
                    CompletedDateTime = DateTime.MinValue
                }
            );

            context.SaveChanges();
        }
    }
}
