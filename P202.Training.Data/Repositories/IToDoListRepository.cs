using P202.Training.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Data.Repositories
{
    public interface IToDoListRepository
    {

        void CreateToDoList(ToDoList user);
        void DeleteToDoList(int id);
        ToDoList UpdateToDoList(ToDoList user);
        ToDoList GetToDoList(int id);
        IList<ToDoList> GetAllToDoList();
    }
}
