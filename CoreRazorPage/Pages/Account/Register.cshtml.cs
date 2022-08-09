using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreRazorPage.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPage.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public RegisterViewModel RegisterUser { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext db)
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
                var user = new IdentityUser
                {
                    UserName = RegisterUser.Email,
                    Email = RegisterUser.Email

                };
                var result = await _userManager.CreateAsync(user, RegisterUser.Password);
                if (result.Succeeded)
                {
                    //add role here
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToPage("Login");
                }
            }
            ModelState.AddModelError("", "Invalid Register.");
            return Page();
        }
    }
}
