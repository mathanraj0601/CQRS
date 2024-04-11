using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    [Authorize]
    public class LogOutModel : PageModel
    {
        public async void OnGet()
        {
            await HttpContext.SignOutAsync();
        }
    }
}
