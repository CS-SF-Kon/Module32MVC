using Microsoft.EntityFrameworkCore;
using Module32MVC.Middlewares;
using Module32MVC.Repositories;

namespace Module32MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connection = builder.Configuration.GetSection("ConnectionStrings").GetValue(typeof(string), "DefaultConnection").ToString();

        builder.Services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        builder.Services.AddScoped<IRequestRepository, RequestRepository>();


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppContext>();
            dbContext.Database.EnsureCreated(); 
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseMiddleware<LoggingMiddleware>();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
