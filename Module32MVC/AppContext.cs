using Microsoft.EntityFrameworkCore;
using Module32MVC.Models.DB;

namespace Module32MVC;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserPost> Posts { get; set; }
    public DbSet<Request> Requs { get; set; }

    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated(); /* до этапа добавления модели для логгирования запросов всё работало нормально, а потом перестало 
                                   * начало вылетать с ошибками SqlException: Недопустимое имя объекта "Requs" и DbUpdateException: An error occurred while saving the entity changes.
                                   * как только сделал таблицу Requs вручную, всё заработало */
        /*а вот когда добавил EnsureDeleted всё заработало
         * получается, EnsureCreated проверяет наличие всей БД, а не таблиц 
         * я столько времени потратил чтоб это понять... */
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information); // логгирование команд к SQL Server
    //}
}
