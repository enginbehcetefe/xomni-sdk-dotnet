﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Private.Analytics
{
    public class DailyCountSummary : WeeklyCountSummary
    {
        public int Day { get; set; }
    }
}
