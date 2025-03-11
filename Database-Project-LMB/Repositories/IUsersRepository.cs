using Database_Project_LMB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database_Project_LMB.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetAll();
        User? GetById(int userId);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}