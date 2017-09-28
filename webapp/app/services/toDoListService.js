define('services/todolistService', ['services/requestHelper'], function (requestHelper) {         
    
    function ListtoDoList() {
      var data = '{"requests":[{"__type":"ToDoListListRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
      return requestHelper.NewAjaxCall(data);
    }
          
    
      return {
        ListtoDoList: ListtoDoList,
      };
    
});