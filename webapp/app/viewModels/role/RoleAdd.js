require('services/roleService');

define('Echo', ['services/roleService'], function (roleService) {


    var rolInsert = function (name) {
        this.Name = name;
    };    

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

        console.log('entre a RoleAdd');        
        console.log(this.name());
        console.log('valor de name upp');

        var RolInsert = new rolInsert(this.name());
        
        console.log('Objeto Rol Insert');
        console.log(RolInsert);
        
       
       
        console.log('Voy a llamar la funcion dice role undefined');
        roleService.roleAdd(this.name()).then(function (response) {
            console.log('dentro');
            vm.roleResponse(response.ProcessJsonRequestsPostResult[0].Value);
        });
    }

    return vm;
});
