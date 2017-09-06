using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.Requests
{
    public class UpdateUserRequest : Request
    {
        public User User { get; set; }
    }
}