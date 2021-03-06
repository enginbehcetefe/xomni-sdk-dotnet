﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Management.Company
{
    public class Device
    {
        public string DeviceId { get; set; }
        public string Description { get; set; }
        public int? DeviceTypeId { get; set; }
        public string DeviceTypeDescription { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int RelatedLicenceId { get; set; }
        public string RelatedLicenceName { get; set; }
    }
}