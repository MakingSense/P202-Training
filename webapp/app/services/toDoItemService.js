define('services/toDoItemService', ['services/requestHelper'], function (requestHelper) {         
    
    function ListtoDoItem() {
      var data = '{"requests":[{"__type":"ToDoItemListRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
      return requestHelper.NewAjaxCall(data);
    }
          
    
      return {
        ListtoDoItem: ListtoDoItem,
      };
    
});