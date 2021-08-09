using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InstaClone.Data;
using InstaClone.Data.Repositories;
using InstaClone.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaClone.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepos _accountRepos;

        public object ClaimTpes { get; private set; }

        public AccountController(IAccountRepos accountRepos)
        {
            _accountRepos = accountRepos;
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_accountRepos.IsUserNameExists(register.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "نام کاربری قبلا انتخاب شده است");
                return View();
            }

            if (_accountRepos.IsEmailExists(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "ایمیل قبلا انتخاب شده است");
                return View();
            }

            var user = new Users()
            {
                Email = register.Email,
                IsAdmin = false,
                Password = register.Password,
                Username = register.UserName,
                RegisterDate = DateTime.Now
            };

            if (register.ProfilePic?.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(register.ProfilePic.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "ProfilePics",
                    fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    register.ProfilePic.CopyTo(stream);
                }

                user.ProfilePic = fileName;
            }


            _accountRepos.AddUser(user);

            return RedirectToAction("Index", register);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var user = _accountRepos.GetUserForLogin(login.Email, login.Password);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (user == null)
            {
                ModelState.AddModelError("Email", "ایمیل یا پسورد اشتباه است!");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("IsAdmin", user.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion
    }
}
