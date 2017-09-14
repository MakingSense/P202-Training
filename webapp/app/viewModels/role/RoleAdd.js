require('services/roleService');

define(['services/roleService'], function (roleService) {
    
    var vm = {
        getView: function () {
            var view = require('./roleAdd.html');
            return $.parseHTML(view)[0];
        },
        name: ko.observable(),
        roleAdd: roleAdd,
        roleResponse: ko.observable('')
    };

    function roleAdd() {
        roleService.roleAdd(this.name()).then(function (response) {              
            route.navigate('#roleList/');            
        });
    }

    return vm;
});
