using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses.ToDoListAndToDoItem
{
    public class ToDoListCreateRequest : Request
    {
        public ToDoList NewToDoList { get; set; }
    }
}