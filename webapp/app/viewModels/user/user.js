define(['services/userService'], function (userService) {
  var vm =  {
    getView: function () {
      var view = require('./user.html');
      return $.parseHTML(view)[0];
    },
    users: ko.observableArray([])
  };

  vm.activate = function(){       
    return userService.ListUsers().then(function(response) {      
      vm.users = response.ProcessJsonRequestsPostResult[0].UserList;
    });    
  };
  
  return vm;
});
