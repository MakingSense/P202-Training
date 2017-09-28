define(['services/toDoListService'], function (toDoListService) {
    var vm =  {
      getView: function () {
        var view = require('./toDoList.html');
        return $.parseHTML(view)[0];
      },
      toDoLists: ko.observableArray([])
    };
  
    vm.activate = function(){       
      return toDoListService.ListtoDoList().then(function(response) {      
        
        vm.toDoLists(response.ProcessJsonRequestsPostResult[0].ToDoListList);
      });    
    };
    
    return vm;
  });
  