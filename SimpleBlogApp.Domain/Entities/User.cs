using SimpleBlogApp.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogApp.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Document { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
