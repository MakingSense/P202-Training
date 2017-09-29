using P202.Training.Domain.Models;
using System.Collections.Generic;

namespace P202.Training.Domain
{
    public interface IToDoListService
    {
        ToDoList CreateToDoList(ToDoList toDoList);
        ToDoList ReadToDoList(int id);
        ToDoList UpdateToDoList(ToDoList toDoList);
        void DeleteToDoList(int id);
        IList<ToDoList> ListToDoList();
    }
}
