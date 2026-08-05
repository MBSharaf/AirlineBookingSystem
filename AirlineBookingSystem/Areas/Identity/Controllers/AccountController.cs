using AirlineBookingSystem.Models;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AirlineBookingSystem.Areas.Identity.Controllers
{
    [Area(CD.IDENTITY_AREA)]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = new ApplicationUser()
            {
                FirstName = registerVM.FirstName , 
                LastName = registerVM.LastName ,
                Email = registerVM.Email ,
                Address = registerVM.Address ,
                UserName = registerVM.UserName ,
                
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("" , error.Description);
                }
                return View(registerVM);
            }

            // send email 
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var Link = Url.Action(nameof(ConfirmEmail), "Account", new {Areas = CD.IDENTITY_AREA , UserId = user.Id , token = token}, Request.Scheme);
            await _emailSender.SendEmailAsync(
                registerVM.Email , 
                "Traveller Confirming Email" ,
                $"<h1>Please Click <a href={Link} >Here</a> To Confirm Your Email</h1>"

                );
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string UserId, string token)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                string errors = "";
                foreach(var error in result.Errors)
                {
                    errors += error.Description + "/n";
                }
                TempData["Error_Notification"] = errors;
                return RedirectToAction(nameof(Login) , "Account" , new {Areas = CD.IDENTITY_AREA});
            }
            TempData["Success_Notification"] = "Email Confirmed successfully";
            return RedirectToAction(nameof(Login), "Account", new { Areas = CD.IDENTITY_AREA });
        }


        [HttpGet]
        public IActionResult ResendConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResendConfirmEmail(ResendConfirmEmailVM resendConfirmEmailVM)
        {
            var user = await _userManager.FindByEmailAsync(resendConfirmEmailVM.UserNameOrEmail) ??
                       await _userManager.FindByNameAsync(resendConfirmEmailVM.UserNameOrEmail);
            if (user is null)
            {
                ModelState.AddModelError("", "Invalid UserNmae Or Password");
                return View(resendConfirmEmailVM);
            }
            // send email 
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var Link = Url.Action(nameof(ConfirmEmail), "Account", new { Areas = CD.IDENTITY_AREA, UserId = user.Id, token = token }, Request.Scheme);
            await _emailSender.SendEmailAsync(
                user.Email,
                "Traveller Confirming Email",
                $"<h1>Please Click <a href={Link} >Here</a> To Confirm Your Email</h1>"

                );
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail) ??
                       await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
            if (user is null)
            {
                ModelState.AddModelError("" , "Invalid UserNmae Or Password");
                return View(loginVM);
            }
            var result = await _signInManager.PasswordSignInAsync(user , loginVM.Password , loginVM.RememberMe , true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "User is Locked Please Try Again after 10 Mins");
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Please confirm Your Email");
                }
                else
                {
                ModelState.AddModelError("", "Invalid UserNmae Or Password");
                }
                return View(loginVM);
            }
            return RedirectToAction("Index" , "Home" , new { area = CD.CUSTOMER_AREA });
        }
    }
}
