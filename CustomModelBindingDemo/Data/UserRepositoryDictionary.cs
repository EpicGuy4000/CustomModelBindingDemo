using System.Collections.Generic;

namespace CustomModelBindingDemo.Data
{
    public class UserRepositoryDictionary : UserRepository
    {
        private static Dictionary<string, User> _users = new Dictionary<string, User>()
        {
            {
                "user@example.com",
                new User()
                {
                    Email = "user@example.com",
                    FirstName = "User",
                    LastName = "Example"
                }
            },
            {
                "another@example.com",
                new User()
                {
                    Email = "another@example.com",
                    FirstName = "Another",
                    LastName = "Example"
                }
            }
        };

        public void Update(User user)
        {
            _users[user.Email] = user;
        }

        public User Retrieve(string email) => _users.ContainsKey(email) ? _users[email] : null;
    }
}