using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreRazorPage.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPage.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public LoginViewModel UserViewModel { get; set; }

        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserViewModel.Email, UserViewModel.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(UserViewModel.Email);
                    //user role list here
                    var roles = await _userManager.GetRolesAsync(user);
                    //get default role here
                    string role = roles.FirstOrDefault();
                    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                        new ClaimsPrincipal(identity));

                    return RedirectToPage("/BookList/Index");
                }
            }
            ModelState.AddModelError("", "Invalid ID or Password");
            return Page();
        }
    }
}
