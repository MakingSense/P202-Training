﻿using Agatha.Common;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class DeleteUserRequest : Request
    {
        public int User { get; set; }
    }
}