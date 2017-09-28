using P202.Training.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Data.Repositories
{
    public interface IToDoItemRepository
    {

        void CreateToDoItem(ToDoItem toDoItem);
        void DeleteToDoItem(int id);
        ToDoItem UpdateToDoItem(ToDoItem toDoItem);
        ToDoItem GetToDoItem(int id);
        IList<ToDoItem> GetAllToDoItem();
    }
}
