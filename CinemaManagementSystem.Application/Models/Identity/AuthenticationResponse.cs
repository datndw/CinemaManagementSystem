﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Models.Identity
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set;}
        public string Email { get; set;}
        public string Token { get; set;}
    }
}
