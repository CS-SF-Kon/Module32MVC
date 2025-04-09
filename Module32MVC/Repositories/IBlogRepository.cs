using Module32MVC.Models.DB;

namespace Module32MVC.Repositories;

public interface IBlogRepository
{
    Task AddUser(User user);
    Task<User[]> GetUsers();
    Task Register(User user);
}
