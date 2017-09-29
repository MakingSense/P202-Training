define([], function ()
{
    var service = {};
    service.NewAjaxCall =
        function (dataService, successCallback, errorCallback) {
            return $.ajax({
                type: 'POST',
                contentType: 'application/json',
                url: 'http://localhost:10160/Service.svc/jsonp/post',
                data: dataService
            });
        };

    return service;
});