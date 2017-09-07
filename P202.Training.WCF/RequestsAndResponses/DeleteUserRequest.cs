using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class DeleteUserRequest : Request
    {
        public int Id { get; set; }
    }
}