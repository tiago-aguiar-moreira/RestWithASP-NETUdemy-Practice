using AuthenticationBearerAndJWT.Model;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationBearerAndJWT.Repository
{
    public static class UserRepository
    {
        private static readonly IList<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                Username = "batman",
                Password = "batman",
                Role = "manager"
            },
            new User
            {
                Id = 2,
                Username = "robin",
                Password = "robin",
                Role = "employee"
            }
        };

        public static User Get(string username, string password) 
            => Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password.ToLower());

        public static IList<User> Get() => Users;

        public static User Get(int id) => Users.FirstOrDefault(f => f.Id == id);
    }
}