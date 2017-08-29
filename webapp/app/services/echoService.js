define('services/echoService', [], function () {

  function echo(value) {
    // TODO: refactor common headers and base url
    return $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url:'http://localhost:10160/Service.svc/jsonp/post',
      data: '{"requests":[{"__type":"EchoRequest:#P202.Training.WCF.RequestsAndResponses","Value":' + value + '}]}'
    });
  }

  return {
    echo: echo
  };

});