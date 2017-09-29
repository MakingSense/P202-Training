using Agatha.ServiceLayer;
using Agatha.Common;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses.ToDoListAndToDoItem;

namespace P202.Training.WCF.Handlers.ToDoListAndToDoItem
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