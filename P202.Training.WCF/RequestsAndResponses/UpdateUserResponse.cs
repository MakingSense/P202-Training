using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class UpdateUserResponse : Response
    {
        public User User { get; set; }
    }
}