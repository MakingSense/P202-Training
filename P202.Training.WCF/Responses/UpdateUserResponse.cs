using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.Responses
{
    public class UpdateUserResponse : Response
    {
        public User User { get; set; }
    }
}