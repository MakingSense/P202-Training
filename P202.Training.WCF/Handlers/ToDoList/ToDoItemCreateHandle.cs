using Agatha.ServiceLayer;
using P202.Training.WCF.RequestsAndResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agatha.Common;
using P202.Training.Domain;

namespace P202.Training.WCF.Handlers.ToDoList
{
    public class ToDoItemCreateHandle : RequestHandler<ToDoItemCreateRquest, ToDoItemCreateResponse>
    {

        private readonly IToDoItemService _toDoItemService;

        public ToDoItemCreateHandle(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public override Response Handle(ToDoItemCreateRquest request)
        {
            var response = CreateTypedResponse();
            response.NewToDoItem = _toDoItemService.CreateToDoItem(request.NewToDoItem);
            return response;
        }
    }
}