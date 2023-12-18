using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;
using System.Linq;
using X.PagedList;


namespace BlogApp.Controllers;

public class HomeController : Controller
{
   private readonly DataContext _context;
   
    public HomeController(DataContext context){
        _context = context;
        
    }


   public IActionResult Index()
    {
        var blogs = _context.Bloglar.ToList(); 
        return View(blogs);
    }
    public IActionResult Details(int id)
{
    var blog = _context.Bloglar.FirstOrDefault(b => b.Id == id);

    if (blog == null)
    {
        return NotFound(); 
    }

    return View(blog);
}
    public IActionResult CreateBlog(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog(Blog model){

        if (ModelState.IsValid)
        {
        // Şu anki tarih ve saat bilgisini al
        model.PostedDate = DateTime.Now;
    
        _context.Bloglar.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Home");
        }
        return View(model);
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
