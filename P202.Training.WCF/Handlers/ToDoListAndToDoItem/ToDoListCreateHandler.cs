using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses.ToDoListAndToDoItem;

namespace P202.Training.WCF.Handlers.ToDoListAndToDoItem
{
    public class ToDoListCreateHandler : RequestHandler<ToDoListCreateRequest, ToDoListCreateResponse>
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListCreateHandler(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        public override Response Handle(ToDoListCreateRequest request)
        {
            var response = CreateTypedResponse();
            response.NewToDoItem = _toDoListService.CreateToDoList(request.NewToDoList);
            return response;
        }
    }
}