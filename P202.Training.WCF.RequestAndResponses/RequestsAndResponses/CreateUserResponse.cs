using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class CreateUserResponse : Response
    {
        public User NewUser { get; set; }
    }
}