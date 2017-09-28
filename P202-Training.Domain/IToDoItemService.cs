using P202.Training.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Domain
{
    public interface IToDoItemService
    {

        ToDoItem CreateToDoItem(ToDoItem toDoItem);
        ToDoItem ReadToDoItem(int id);
        ToDoItem UpdateToDoItem(ToDoItem toDoItem);
        void DeleteToDoItem(int id);
        IList<ToDoItem> ListToDoItem();


        
    }
}
