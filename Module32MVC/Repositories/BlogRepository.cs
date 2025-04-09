using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module32MVC.Models.DB;

namespace Module32MVC.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly AppContext _context;

    public BlogRepository(AppContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        var entry = _context.Entry(user);
        if (entry.State == EntityState.Detached)
            await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task <User[]> GetUsers()
    {
        return await _context.Users.ToArrayAsync();
    }

    [HttpPost]
    public async Task Register(User user) // не понял, это не нужный что ли метод? 
    {
        user.JoinDate = DateTime.Now; // специально добавил вывод в консоли, чтоб отследить, будет ли он вызван
        user.Id = Guid.NewGuid(); // а он не вызывается, при этом отрабатывает создание пользователя в контроллере, отрабатывает присвоение Guid, но не даты создания
        Console.WriteLine($"{user.JoinDate} {user.Id}");
        var entry = _context.Entry(user);
        if (entry.State == EntityState.Detached)
            await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }
}
