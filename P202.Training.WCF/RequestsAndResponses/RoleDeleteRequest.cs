﻿using Agatha.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class RoleDeleteRequest : Request
    {
        public int RoleId { get; set; }
    }
}