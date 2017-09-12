require('services/roleService');

define(['services/roleService'], function (roleService) {


    // Class to represent a row in the seat reservations grid
    function rol(id,name,createdby) {
        var self = this;
        self.name = name;
        self.createdby = createdby;
        self.id = id;
        
    }

  var vm = {
    getView: function () {
      var view = require('./roleList.html');
      return $.parseHTML(view)[0];
    },
    roles: ko.observableArray([])   
    };
    
    vm.activate = function () {

        return roleService.roleReadAll().then(function (response) {
            vm.roles(response.ProcessJsonRequestsPostResult[0].Roles);
        });

    };

  return vm;
});
