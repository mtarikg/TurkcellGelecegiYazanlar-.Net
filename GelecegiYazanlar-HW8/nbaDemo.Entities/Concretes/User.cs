using nbaDemo.Entities.Abstracts;
using System;

namespace nbaDemo.Entities
{
    [Flags]
    public enum AuthorizeRoles
    {
        None = 0,
        Administrator = 1,
        Editor = 2,
        Fan = 3
    }

    public class User : IEntity
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthorizeRoles Role { get; set; }
    }
}
