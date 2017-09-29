using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Domain.Models
{
    public class ToDoItem : Base
    {
        public string Description { get; set; }
        public int Priority { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
