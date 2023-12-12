using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

   public IActionResult Index()
    {
        var blog = new List<Blog>()
        {
        new Blog { Id = 1,Image="1.jpg", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
        new Blog { Id = 1,Image="1.jpg", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
        new Blog { Id = 1,Image="1.jpg", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
        new Blog { Id = 1,Image="1.jpg", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
       
        };
        return View(blog);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
