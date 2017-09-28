using Agatha.Common;
using P202.Training.Domain.Models;
using System.Collections.Generic;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ToDoListListResponse : Response
    {
        public IList<ToDoList> ToDoListList { get; set; }
    }
}