using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessApp.Business.Abstract;
using BusinessApp.Entity;
using BusinessApp.WebUI.EmailServices;
using BusinessApp.WebUI.Extensions;
using BusinessApp.WebUI.Identity;
using BusinessApp.WebUI.Models;
using BusinessApp.WebUI.Models.AccountModels;
using BusinessApp.WebUI.Models.UsersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<AccountController> _logger;

        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ICompanyService _companyService;
        private IEmailSender _emailSender;
        private IUsersApplicaitonService _usersApplicationService;
        public AccountController(RoleManager<IdentityRole> roleManager
            ,UserManager<User> userManager
            , ICompanyService companyService
            , IUsersApplicaitonService usersApplicationService
            , SignInManager<User> signInManager
            , IEmailSender emailSender
            , INotyfService notyf
            , ILogger<AccountController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _companyService = companyService;
            _usersApplicationService = usersApplicationService;
            _signInManager = signInManager;

            _emailSender = emailSender;

            _notyf = notyf;
            _logger = logger;
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            var firms = _companyService.GetAll();
            ViewBag.Firms = firms;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UsersApplicationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = false,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var isThereRole = await _roleManager.RoleExistsAsync("Customer");
                if (!isThereRole)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Customer"));
                }
                await _userManager.AddToRoleAsync(user, "Customer");
                var userId = _userManager.Users.Where(c => c.Email == model.Email).Select(c => c.Id).FirstOrDefault();
                var application = new UsersApplication()
                {
                    CompanyName = model.CompanyName,
                    ApplicationStatus= UsersApplication.EnumApplicationStatus.Waiting,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    EmailConfirmed=false,
                    PhoneNumber = model.PhoneNumber,
                    UserName=model.Email,
                    UserId = userId
                };
                _usersApplicationService.Create(application);

                _notyf.Success("Success Notification.");

                return Redirect("/Home/Index");
            }
            ModelState.AddModelError("",result.Errors.FirstOrDefault().Description.ToString());

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                _notyf.Warning("No registered user with e-mail address was found.");

                return View(model);
            }
            if (user.EmailConfirmed != true) {
                _notyf.Information("Waiting For Email Confirmation.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                _notyf.Success("You Are Successfully Logged In.");

                return RedirectToAction("Index","Home");
            }
            _notyf.Error("Email or password is incorrect.");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            
            _notyf.Information("Your account has been successfully logged out.");
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult Accessdenied()
        {            
            _notyf.Information("You do not have permission to access this page. ");
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var roles = ((ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).FirstOrDefault();
            var profile = new UserModel()
            {
                UserName = user.UserName,
                UserRole = roles
            };
            return View(profile);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = token
            });
            Console.WriteLine(url);

            //email
            await _emailSender.SendEmailAsync(email, "Reset Account Password.",
                $"Please <a href='https://localhost:44342{url}'> click </a> link to reset account password.");

            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Home", "Index");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

    }
}
