using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses.ToDoListAndToDoItem;

namespace P202.Training.WCF.Handlers.ToDoListAndToDoItem
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