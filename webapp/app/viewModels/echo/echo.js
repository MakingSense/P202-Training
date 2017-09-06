require('services/echoService');

define('Echo', ['services/echoService'], function (echoService) {
  var vm = {
    getView: function () {
      var view = require('./echo.html');
      return $.parseHTML(view)[0];
    },
    value: ko.observable(0),
    sendEcho: sendEcho,
    echoResponse: ko.observable('')
  };

  function sendEcho() {
    return echoService.echo(this.value()).then(function(response) {
      vm.echoResponse(response.ProcessJsonRequestsPostResult[0].Value);
    });
  }

  return vm;
});
