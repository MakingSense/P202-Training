define(['services/requestHelper'], function (requestHelper)
{
    var service = {};

    service.echo =
        function (value) {
            var data = '{"requests":[{"__type":"EchoRequest:#P202.Training.WCF.RequestsAndResponses","Value":"' + value + '"}]}';
            return requestHelper.NewAjaxCall(data);
        };

    return service;

});
