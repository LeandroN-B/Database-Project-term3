using System.Collections.Generic;

namespace Database_Project_LMB.Models
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetUserByID(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
