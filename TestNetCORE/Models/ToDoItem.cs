using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCORE.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsChecked { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime EndDateTime { get; set; }
        public DateTime? CompletedDateTime { get; set; }
        public DateTime LastTimeModified { get; set; }
    }
}
