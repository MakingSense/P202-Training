using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ToDoListReadResponse : Response
    {
        public ToDoList ToDoList { get; set; }
    }
}