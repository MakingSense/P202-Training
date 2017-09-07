define('services/requestHelper', [], function () {
  function NewAjaxCall(dataService, successCallback, errorCallback) {
    return $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: 'http://localhost:10160/Service.svc/jsonp/post',
      data: dataService
    });
  }

  return {
    NewAjaxCall: NewAjaxCall
  };
});
