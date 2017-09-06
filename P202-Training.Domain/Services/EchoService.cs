using P202.Training.Domain.Services.Interfaces;

namespace P202.Training.Domain.Services
{
    public class EchoService : IEchoService
    {
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }
    }
}
