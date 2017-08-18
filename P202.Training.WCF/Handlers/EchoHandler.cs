using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class EchoHandler : RequestHandler<EchoRequest, EchoResponse>
    {
        private readonly IEchoService _echoService;

        public EchoHandler(IEchoService echoService)
        {
            _echoService = echoService;
        }

        public override Response Handle(EchoRequest request)
        {
            var response = CreateTypedResponse();
            response.Value = _echoService.GetData(request.Value);
            return response;
        }
    }
}