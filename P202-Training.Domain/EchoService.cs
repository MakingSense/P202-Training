namespace P202.Training.Domain
{
    public class EchoService : IEchoService
    {
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }
    }
}
