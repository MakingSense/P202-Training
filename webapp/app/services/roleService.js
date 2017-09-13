define('services/roleService', [], function () {

    function roleReadAll() {        
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleReadAllRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
        });
    }

    function roleAdd(roleName) {
        var role = {"Name":roleName};              
        var roleJson = JSON.stringify(role);        
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleAddRequest:#P202.Training.WCF.RequestsAndResponses","Role":' + roleJson + '}]}'
        });
    }

    function roleDelete(roleId) {        
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleDeleteRequest:#P202.Training.WCF.RequestsAndResponses","RoleId":' + roleId + '}]}'
        });
    }

    return {
        roleReadAll: roleReadAll,
        roleAdd: roleAdd,
        roleDelete: roleDelete,
    };

});