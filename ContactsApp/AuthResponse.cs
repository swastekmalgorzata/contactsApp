using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class AuthResponse
    {
        public string Emial { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
