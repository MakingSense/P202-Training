define(['viewModels/echo/echo', 'services/echoService'], function (echoViewModel, echoService) {

  var fakeEchoResponse = {
    ProcessJsonRequestsPostResult: [
      {
        __type: "EchoResponse:#P202.Training.WCF.RequestsAndResponses",
        Value: "You entered: 5"
      }
    ]
  };

  beforeEach(function () {
    spyOn(echoService, 'echo').and.callFake(function () {
      return Q(fakeEchoResponse);
    });
  });

  describe('echo viewModel', function () {

    it('should be not null', function () {
      // Assert
      expect(echoViewModel).not.toBe(null);
    });

    it('sendEcho should call echoService with value and update VM', function () {
      // Arrange
      var valueToTest = 5;
      echoViewModel.value(valueToTest);

      // Act
      echoViewModel.sendEcho().then(function () {

        // Assert
        expect(echoService.echo).toHaveBeenCalledTimes(1);
        expect(echoService.echo).toHaveBeenCalledWith(valueToTest);
        expect(echoViewModel.echoResponse()).toBe(fakeEchoResponse.ProcessJsonRequestsPostResult[0].Value);
      });
    });

  });

});
