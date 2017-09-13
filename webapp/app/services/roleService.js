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
        // TODO: refactor common headers and base url  
        console.log('roleServie - roleDelete');
        console.log('valor de roleId');
        console.log(roleId);
        console.log('valor de roleId');
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