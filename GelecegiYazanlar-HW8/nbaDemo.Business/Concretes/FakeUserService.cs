using nbaDemo.Business.Abstracts;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace nbaDemo.Business.Concretes
{
    public class FakeUserService : IUserService
    {
        private readonly List<User> users;

        public FakeUserService()
        {
            users = new List<User>
            {
                new User {ID = 1, Email = "user1@test.com", FullName = "Admin One", Password = "123", Username = "user1", Role = AuthorizeRoles.Administrator},
                new User {ID = 2, Email = "user2@test.com", FullName = "Editor One", Password = "456", Username = "user2", Role = AuthorizeRoles.Editor},
                new User {ID = 3, Email = "user3@test.com", FullName = "Fan One", Password = "789", Username = "user3", Role = AuthorizeRoles.Fan}
            };
        }
        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
