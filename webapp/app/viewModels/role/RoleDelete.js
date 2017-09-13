require('services/roleService');

define(['services/roleService'], function (roleService) {
    
    var vm = {
        getView: function () {
            var view = require('./roleDelete.html');
            return $.parseHTML(view)[0];
        },
        name: ko.observable(0),
        roleDelete: roleDelete,
        roleResponse: ko.observable('')
    };

    function roleDelete() {        
        roleService.roleDelete(this.name()).then(function (response) {            
            vm.roleResponse(response.ProcessJsonRequestsPostResult[0].Value);
        });
    }

    return vm;
});
