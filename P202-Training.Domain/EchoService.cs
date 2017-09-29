namespace P202.Training.Domain
{
    public class EchoService : IEchoService
    {
        public string GetData(string value)
        {
            return $"You entered: {value}";
        }
    }
}
