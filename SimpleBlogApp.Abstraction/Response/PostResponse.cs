﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogApp.Abstraction.DTO
{
    public class PostResponse
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
    }
}
