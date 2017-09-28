using Agatha.Common;
using P202.Training.Domain.Models;
using System.Collections.Generic;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ToDoItemListResponse : Response
    {

        public IList<ToDoItem> ToDoItemList { get; set; }
    }
}