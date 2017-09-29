define(['services/echoService'], function (echoService)
{
    function sendEcho()
    {
        return echoService.echo(this.value()).then(function (response)
        {
            vm.echoResponse(response.ProcessJsonRequestsPostResult[0].Value);
        });
    }

    var vm = {
                value: ko.observable(0),
                sendEcho: sendEcho,
                echoResponse: ko.observable('')
            };

    return vm;
});
