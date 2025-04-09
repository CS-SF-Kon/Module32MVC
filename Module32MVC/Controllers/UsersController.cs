using Microsoft.AspNetCore.Mvc;
using Module32MVC.Models.DB;
using Module32MVC.Repositories;

namespace Module32MVC.Controllers;

public class UsersController : Controller
{
    private readonly IBlogRepository _repo;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IBlogRepository repo, ILogger<UsersController> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _repo.GetUsers();

        //Console.WriteLine("See all blog authors:");
        //foreach (var author in authors)
        //    Console.WriteLine($"Author name {author.FirstName}, joined {author.JoinDate}");

        return View(authors);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User newUser)
    {
        newUser.JoinDate = DateTime.Now;
        await _repo.AddUser(newUser);
        return View(newUser);
    }
}
