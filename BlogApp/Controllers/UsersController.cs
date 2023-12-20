using BlogApp.Data;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp.Controllers
{
    public class UsersController : Controller {

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View();
    }
      public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
}

    }
