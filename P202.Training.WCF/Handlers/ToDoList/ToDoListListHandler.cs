using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P202.Training.WCF.Handlers
{
    public class ToDoListListHandler : RequestHandler<ToDoListListRequest, ToDoListListResponse>
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListListHandler(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        public override Response Handle(ToDoListListRequest request)
        {
            var response = CreateTypedResponse();
            response.ToDoListList = _toDoListService.ListToDoList();

            return response;
        }
    }
}