using Agatha.Common;

namespace P202.Training.WCF.Requests
{
    public class DeleteUserRequest : Request
    {
        public int User { get; set; }
    }
}