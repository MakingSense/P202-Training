using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ReadUserRequest : Request
    {
        public User User { get; set; }
    }
}