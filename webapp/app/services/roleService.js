define('services/roleService', [], function () {

  function roleReadAll() {
    // TODO: refactor common headers and base url
    return $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: 'http://localhost:10160/Service.svc/jsonp/post',
      data: '{"requests":[{"__type":"RoleReadAllRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
    });
  }

  return {
    roleReadAll: roleReadAll
  };

});
