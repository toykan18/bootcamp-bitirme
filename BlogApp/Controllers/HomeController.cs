using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;



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
         if (User?.Identity?.IsAuthenticated != true)
    {
        // Kullanıcı giriş yapmamışsa, sayfayı gösterme
        return RedirectToAction("Login", "Users"); // Kullanıcıyı giriş sayfasına yönlendir
    }

    return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog(Blog model){

        if (ModelState.IsValid)
        {
        model.PostedDate = DateTime.Now;
        model.Author = User.Identity?.Name;
    
        _context.Bloglar.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Home");
        }
        return View(model);
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


   
   
}
