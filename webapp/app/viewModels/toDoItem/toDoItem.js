define(['services/toDoItemService'], function (toDoItemService) {
    var vm =  {
      getView: function () {
        var view = require('./toDoItem.html');
        return $.parseHTML(view)[0];
      },
      toDoItems: ko.observableArray([])
    };
  
    vm.activate = function(){       
      return toDoItemService.ListtoDoItem().then(function(response) {      
        
        vm.toDoItems(response.ProcessJsonRequestsPostResult[0].ToDoItemList);
      });    
    };
    
    return vm;
  });
  