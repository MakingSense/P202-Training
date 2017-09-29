define(['services/userService'], function (userService)
{
    var vm = { users: ko.observableArray([]) };

    vm.activate = function()
    {       
        return userService.ListUsers().then(function (response)
        {      
            vm.users = response.ProcessJsonRequestsPostResult[0].UserList;
        });    
    };
  
  return vm;
});
