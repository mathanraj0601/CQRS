using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }
        [BindProperty]
        public string? Password { get; set; }

        [BindProperty(SupportsGet =true)]
        public string? ReturnUrl { get; set; }
        public async void OnGet()
        {
            

        }

        public async Task<IActionResult> OnPost()
        {
            if (UserName == "admin" && Password == "admin")
            {
                var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "John Doe"),
                new Claim(ClaimTypes.Email, "email"),
                new Claim("sub","123")
            };
                var claimsIdentity = new ClaimsIdentity(claim, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return LocalRedirect(ReturnUrl);
            }
               return Page();
        }
    }
}
