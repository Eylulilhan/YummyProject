﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public  String Address { get; set; }
        public string Email{ get; set; }
        public string  PhoneNumber{ get; set; }
        public string MapUrl{ get; set; }
        public string OpenHours{ get; set; }

    }
}