﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class AuthRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
