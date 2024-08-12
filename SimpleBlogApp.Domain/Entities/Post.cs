using SimpleBlogApp.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogApp.Domain.Entities
{
    public class Post : Entity
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public User User { get; set; }
    }
}
