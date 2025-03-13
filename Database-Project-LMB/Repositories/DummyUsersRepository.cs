using Microsoft.AspNetCore.Mvc;

/*

namespace Database_Project_LMB.Models
{
    public class DummyUsersRepository : IUserRepository
    {
        private List<User> _users = new List<User>
        {
            new User(1, "Alice", "1234567890", "alice@email.com"),
            new User(2, "Bob", "0987654321", "bob@email.com")
        };

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetUserByID(int id)
        {
            return _users.Find(user => user.UserID == id);
        }

        public void Add(User user)
        {
            user.UserID = _users.Count + 1;
            _users.Add(user);
        }

        public void Update(User user)
        {
            var existingUser = GetUserByID(user.UserID);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.MobileNumber = user.MobileNumber;
                existingUser.Email = user.Email;
            }
        }

        public void Delete(User user)
        {
            _users.RemoveAll(u => u.UserID == user.UserID);
        }
    }
}
*/