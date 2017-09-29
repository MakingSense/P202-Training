define(['services/roleService'], function (roleService)
{
    var vm = { roles: ko.observableArray([])  };

    vm.activate = function ()
    {
        return roleService.roleReadAll().then(function (response)
        {
            vm.roles(response.ProcessJsonRequestsPostResult[0].Roles);
        });

    };

  return vm;
});
