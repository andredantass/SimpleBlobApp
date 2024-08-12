﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogApp.Abstraction.DTO
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Document { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
