﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ManageStudent_BO.Models
{
    public partial class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
