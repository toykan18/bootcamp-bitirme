using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;

namespace BlogApp.Controllers;

public class HomeController : Controller
{
   private readonly DataContext _context;
    public HomeController(DataContext context){
        _context = context;
    }


   public IActionResult Index()
    {
        return View(Repository.blogs);
    }
    public IActionResult Details(int id){
        var blog = Repository.GetById(id);
        return View(blog);
    }
    public IActionResult About()
    {
        return View();
    }
      public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
      public async Task<IActionResult> Contact(Contact model)
    {
        _context.Contact.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Home");
    }


     public IActionResult Register()
    {
        return View();
    }
      public IActionResult Login()
    {
        return View();
    }

   
}
