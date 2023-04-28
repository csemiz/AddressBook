using AddressBookEL.IdentityModels;
using AddressBookPL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var sameUser = _userManager.FindByNameAsync(model.Username).Result; //async bir metodun sonuna .Result yazarsak senkron çalışır.

                if (sameUser != null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı ismi sistemde mevcuttur! Farklı kullanıcı adı deneyiniz!");
                }

                sameUser = _userManager.FindByEmailAsync(model.Email).Result; //async bir metodun sonuna .Result yazarsak senkron çalışır.

                if (sameUser != null)
                {
                    ModelState.AddModelError("", "Bu email sistemde mevcuttur! Farklı email deneyiniz!");
                }
                //artık sisteme kayıt olabilir.
                AppUser user = new AppUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.Phone,
                    UserName = model.Username,
                    Email = model.Email,
                    BirthDate = model.Birthdate,
                    CreatedDate = DateTime.Now,
                    EmailConfirmed = true,
                    IsPassive = false
                };
                if (model.Birthdate != null)
                {
                    user.BirthDate = model.Birthdate;
                }

                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    //kullanıcıya customer rolünü atayalım
                    var roleResult = _userManager.AddToRoleAsync(user, "Customer").Result;
                    if (roleResult.Succeeded)
                    {
                        TempData["RegisterSuccessMsg"] = "Kayıt Başarılı";
                    }
                    else
                    {
                        TempData["RegisterWarningMsg"] = "Kullanıcı oluştu! Ancak rolü atanamadı! Sistem yöneticisine ulaşarak rol ataması yapılmalıdır!";
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Ekleme başarısız!");
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik hata oluştu!" + ex.Message);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = _userManager.FindByNameAsync(model.UsernameorEmail).Result;
                if (user == null)
                {
                    user = _userManager.FindByEmailAsync(model.UsernameorEmail).Result;
                }
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı/Email ya da şifre hatalıdır!");
                    return View(model);
                }

                var signinResult = _signInManager.PasswordSignInAsync(user, model.Password, true, true).Result;
                if (signinResult.Succeeded)
                {
                    //Yönlendirme yapılacak
                    if (_userManager.IsInRoleAsync(user, "Customer").Result)
                    {
                        TempData["LoggedInUsername"] = user.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else if (_userManager.IsInRoleAsync(user, "Admin").Result)
                    {
                        return RedirectToAction("Dashboard", "Admin", new { area = "" }); //areayı unutma
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (signinResult.IsLockedOut)
                {
                    //user.LockoutEnd = DateTime.Now.AddMinutes(1);
                    //var r = _userManager.UpdateAsync(user).Result;
                    ModelState.AddModelError("", $"2 defa yanlış işlem yaptığınız için {user.LockoutEnd.Value.ToString("HH:mm:ss")} den sonra giriş yapabilirsiniz.");
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "Giriş Başarısız");
                    return View(model);
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu" + ex.Message);
                return View(model);
            }
        }

        [Authorize]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            TempData["LoggedInUsername"] = null;
            return RedirectToAction("Index", "Home");
        }
    }

}
