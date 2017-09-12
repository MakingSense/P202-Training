define('services/roleService', [], function () {

    function roleReadAll() {
        console.log('Entre a llamar WebService')
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleReadAllRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
        });
    }

    function roleAdd(value) {
        var roleIns = {
            "Name":value
        };              
        var roleInsJs = JSON.stringify(roleIns);
        return $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: 'http://localhost:10160/Service.svc/jsonp/post',
            data: '{"requests":[{"__type":"RoleAddRequest:#P202.Training.WCF.RequestsAndResponses","Role":' + roleInsJs + '}]}'
        });
    }

    return {
        roleReadAll: roleReadAll,
        roleAdd: roleAdd
    };

});