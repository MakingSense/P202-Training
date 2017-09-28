using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Data.Entities
{
    public class ToDoItem : Base
    {

        /// <summary>
        /// Description of the task.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// ToDoItem Priority
        /// </summary>
        public virtual int Priority { get; set; }

        /// <summary>
        /// ToDoList 
        /// </summary>
        public virtual ToDoList ToDoList { get; set; }
    }
}
