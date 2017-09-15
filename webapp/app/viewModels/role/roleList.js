require('services/roleService');

define(['services/roleService'], function (roleService) {
    
  var vm = {
    getView: function () {
      var view = require('./roleList.html');
      return $.parseHTML(view)[0];
    },
    roles: ko.observableArray([]),
    roleResponse: ko.observable(''),
    remove: function (role) {       
        roleService.roleDelete(role.Id).then(function (response) {
            if (response.ProcessJsonRequestsPostResult[0].Deleted) {
                vm.roles.remove(role);
                vm.roleResponse("The role " + role.Name + " has been successfully removed");
            }
            else {
                vm.roleResponse("The role " + role.Name + " could not be removed, try after please");
            }
        }).catch(function () {
            vm.roleResponse("there was a Problem, try later");
        });
    }    
    };

    vm.activate = function () {
        return roleService.roleReadAll().then(function (response) {           
            vm.roles(response.ProcessJsonRequestsPostResult[0].Roles);            
        });
    };

  return vm;
});
