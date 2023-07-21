using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheRealManSys.Models;
using Microsoft.EntityFrameworkCore;
using TheRealManSys.Data;
using TheRealManSys.ViewModels;

namespace TheRealManSys.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly ManSysIdentityContext DbContext;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger, SignInManager<User> signInManager, RoleManager<Role> roleManager, ManSysIdentityContext manSysIdentityContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.DbContext = manSysIdentityContext;
            this.logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Input != null && model.Input.Email != null && model.Input.Password != null)
                {

                    var result = await signInManager.PasswordSignInAsync(model.Input.Email, model.Input.Password, model.Input.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный логин или пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Поля не должны оставаться пустыми.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel.FirstRegister = DbContext.Users.Count() == 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User{ Email = model.Input.Email, UserName = model.Input.Email, PhoneNumber = model.Input.PhoneNumber, Surname = model.Input.SurName, Name = model.Input.Name};
                var result = await userManager.CreateAsync(user, model.Input.Password);

                #region firstTimeRegistrationCreateAdmin
                if (RegisterViewModel.FirstRegister)
                {
                    Role role = new Role()
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    };
                    await roleManager.CreateAsync(role);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                #endregion

                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
