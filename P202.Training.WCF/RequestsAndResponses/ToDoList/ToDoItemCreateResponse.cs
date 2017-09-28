using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ToDoItemCreateResponse : Response
    {
        public ToDoItem NewToDoItem { get; set; }
    }
}