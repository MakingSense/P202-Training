using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ToDoListCreateResponse : Response
    {

        public ToDoList NewToDoItem { get; set; }
    }
}