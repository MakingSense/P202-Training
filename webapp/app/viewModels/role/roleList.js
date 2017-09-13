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
        var id = role.Id;
        roleService.roleDelete(id).then(function (response) {
            vm.roleResponse(response.ProcessJsonRequestsPostResult[0].Value);
        })
    }
    
    };

  //vm.remove = function(id) {

  //      console.log('Delete');
  //      console.log('en vm.remove')
  //      console.log(id)
  //      console.log('valor de id')
  //      //roleService.roleDelete(id)
  //      roleService.roleDelete(id).then(function (response) {
  //          console.log('Response Delete');
  //          console.log(response.ProcessJsonRequestsPostResult[0].Value);
  //          vm.roleResponse(response.ProcessJsonRequestsPostResult[0].Value);
  //      });

  //};
    
    vm.activate = function () {

        return roleService.roleReadAll().then(function (response) {
            //var roless = response.ProcessJsonRequestsPostResult[0].Roles;  
            
            vm.roles(response.ProcessJsonRequestsPostResult[0].Roles);
            //vm.roles(roless);
        });

    };

  return vm;
});
