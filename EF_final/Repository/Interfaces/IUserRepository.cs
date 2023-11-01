using EF_final.Models;

namespace EF_final.Repository.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        User GetUserById(int id);
        List<User> GetUsers();
        void UpdateUser(int id, string name);
        int UserBooksCount(int id);
        void Save();
    }
}