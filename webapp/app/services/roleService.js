var rolInsert = function (name) {
    this.Name = name;
};

define('services/roleService', [], function () {



    function roleReadAll() {
        // TODO: refactor common headers and base url
        console.log('Entre a llamar WebService')
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleReadAllRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
        });
    }

    function roleAdd(value) {
        // TODO: refactor common headers and base url

        console.log('dentro de roleAdd de roleservices');
        console.log('valor de rolesservices');
        console.log(value);
        console.log('valor Rol');
        var RoleInsert = new rolInsert(value);
        console.log(RoleInsert);
        console.log('valor Rol');
        var RoleInsertJ = JSON.stringify(RoleInsert);

        console.log('valor Rol JSON');
        console.log(RoleInsertJ);

        console.log('Ejecuto Ajax');
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleAddRequest:#P202.Training.WCF.RequestsAndResponses","Role":' + RoleInsertJ + '}]}'
        });
    }

    return {
        roleReadAll: roleReadAll,
        roleAdd: roleAdd
    };

});