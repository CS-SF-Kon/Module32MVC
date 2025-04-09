using Microsoft.AspNetCore.Mvc;
using Module32MVC.Models.DB;
using Module32MVC.Repositories;

namespace Module32MVC.Controllers;

public class LogsController : Controller
{
    private readonly IRequestRepository _reqlog;
    private readonly ILogger<UsersController> _logger;


    public LogsController(IRequestRepository reqlog, ILogger<UsersController> logger)
    {
        _reqlog = reqlog;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var reqlogs = await _reqlog.GetRequests();
        Console.Write(reqlogs);
        return View(reqlogs);
    }
}
