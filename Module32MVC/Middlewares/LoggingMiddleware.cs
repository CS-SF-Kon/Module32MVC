using Module32MVC.Models.DB; // модели для ORM
using Module32MVC.Repositories; // подгружаем RequestRepository

namespace Module32MVC.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IRequestRepository repo) // 
    {
        //Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value} + {context.Request.Path}"); // заменим вывод в консоль на запись в БД

        var newRequest = new Request()
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            Url = $"http://{context.Request.Host.Value + context.Request.Path}"
        };


        try
        {
            //Console.WriteLine($"{newRequest.Id} - {newRequest.Date} - {newRequest.Url}"); // оставим для проверки через консоль
            await repo.AddRequest(newRequest); // запишем в БД
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        await _next.Invoke(context);
    }
}
