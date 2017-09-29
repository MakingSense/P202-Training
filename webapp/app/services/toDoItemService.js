define('services/toDoItemService', ['services/requestHelper'], function (requestHelper) {         
    
    function ListtoDoItem() {
      var data = '{"requests":[{"__type":"ToDoItemListRequest:#P202.Training.WCF.RequestsAndResponses.ToDoListAndToDoItem"}]}'
      return requestHelper.NewAjaxCall(data);
    }
          
    
      return {
        ListtoDoItem: ListtoDoItem,
      };
    
});