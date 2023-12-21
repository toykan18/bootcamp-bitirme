using BlogApp.Data;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlogApp.Controllers
{
    public class UsersController : Controller {

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

    public async Task<IActionResult> Edit(string id){

        if(id == null){
           return RedirectToAction("Index");
        }
        var user = await _userManager.FindByIdAsync(id);

        if(user != null){

            ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();

             return View(new EditViewModels{
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user),
             });
        }

      return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Edit(string id, EditViewModels model){

        if(id != model.Id){
            return RedirectToAction("Index");
        }
        if(ModelState.IsValid){
            var user = await _userManager.FindByIdAsync(model.Id);
            if(user != null){
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded && !string.IsNullOrEmpty(model.Password)){
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
                if(result.Succeeded){
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    if(model.SelectedRoles != null){
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                    }
                    return RedirectToAction("Index");
                }
                foreach(IdentityError err in result.Errors){
                    ModelState.AddModelError("", err.Description);
                }
            }
            
        }
            return View(model);
    }

    [HttpPost]

    public async Task<IActionResult> Delete(string id){
        var user = await _userManager.FindByIdAsync(id);
        if(user != null){
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction("Index");
    }
}

    
    }
