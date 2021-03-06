﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics.Log
{
    public class OmniShareAnalyticsLog : BaseAnalyticsLog
    {
        public int SharedFromApiUserId { get; set; }
        public string SharedFromApiUsername { get; set; }
        public int SharedToApiUserId { get; set; }
        public string SharedToApiUsername { get; set; }
        public int PIIUserId { get; set; }
        public string PIIUsername { get; set; }
        public Guid OmniTicket { get; set; }
    }
}
