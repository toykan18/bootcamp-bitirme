using BlogApp.Data;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp.Controllers
{
    public class UsersController : Controller {

        private UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager){
            _userManager = userManager;
        }
        public IActionResult Index (){
            return View(_userManager.Users);
        }
          public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
          public async Task<IActionResult> Register(RegisterViewModels model){

            if(ModelState.IsValid){
                var user = new AppUser{UserName = model.UserName, Email = model.Email};
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded){
                    return RedirectToAction("Index", "Home");
                }

                foreach(IdentityError err in result.Errors){
                    ModelState.AddModelError("", err.Description);
                }

            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}