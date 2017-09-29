define(['services/toDoListService'], function (toDoListService) {
    var vm =  {
      getView: function () {
        var view = require('./AddToDoList.html');
        return $.parseHTML(view)[0];
      },
      //toDoLists: ko.observableArray([])
      toDoList: ko.observable()
    };
  
    vm.activate = function(){ 
        /*      
      return toDoListService.ListtoDoList().then(function(response) {      
        
        vm.toDoLists(response.ProcessJsonRequestsPostResult[0].ToDoListList);
      }); 
      */   
    };
    
    return vm;
  });
  