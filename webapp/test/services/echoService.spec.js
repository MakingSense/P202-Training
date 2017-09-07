define(['services/echoService', 'jquery'], function(echoService, jquery) {

  beforeEach(function () {
    spyOn(jquery, 'ajax').and.callFake(function() {
        return Q({});
    });
  });

  describe('echoService', function(){
    
    it('should be not null', function(){
      // Assert
      expect(echoService).not.toBe(null);
    });

    it('echo should perform POST request', function() {
      
      // Act
      echoService.echo(1);

      // Assert
      expect(jquery.ajax).toHaveBeenCalledTimes(1);
    });

  });

});