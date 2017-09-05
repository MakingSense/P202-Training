require('services/roleService');

define(['services/roleService'], function (roleService) {
  var vm = {
    getView: function () {
      var view = require('./roleList.html');
      return $.parseHTML(view)[0];
    },
    roles: ko.observableArray([])   
    };
    

    vm.activate = function () {

        return roleService.roleReadAll().then(function (response) {
            console.log(response.ProcessJsonRequestsPostResult[0].Roles);

            vm.roles(response.ProcessJsonRequestsPostResult[0].Roles);
        });

    };

  return vm;
});
