using Microsoft.AspNetCore.Mvc;
using Module32MVC.Models;
using System.Diagnostics;

namespace Module32MVC.Controllers;

public class FeedbackController : Controller // я не понимаю, у других контроллеров мы создаём _logger, а тут не создаём, и всё равно LoggingMiddleware срабатывает
{
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Feedback feedback)
    {
        return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
