using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses.ToDoListAndToDoItem;

namespace P202.Training.WCF.Handlers.ToDoList
{
    public class ToDoItemListHandler : RequestHandler<ToDoItemListRequest, ToDoItemListResponse>
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemListHandler(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public override Response Handle(ToDoItemListRequest request)
        {
            var response = CreateTypedResponse();
            response.ToDoItemList = _toDoItemService.ListToDoItem();

            return response;
        }
    }
}