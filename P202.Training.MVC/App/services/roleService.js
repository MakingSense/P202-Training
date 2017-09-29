define(['services/requestHelper'], function (requestHelper) {
    var service = {};
    
    service.roleReadAll =
        function ()
        {
            var data = '{"requests":[{"__type":"RoleReadAllRequest:#P202.Training.WCF.RequestsAndResponses"}]}';
            return requestHelper.NewAjaxCall(data);     
        };

    return service;
});