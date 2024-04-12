using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;

namespace RazorPages.Pages
{
    [Authorize]
    public class AddPersonModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        public bool isFailed { get; set; }
        private readonly HttpClient _httpClient;
        public AddPersonModel(HttpClient httpClient)
        {
            product = new Product();
            _httpClient = httpClient;
            isFailed = false;

        }

        public void OnGet()
        {
        }

        public async Task<Product?> AddPerson(Product product)
        {
            try
            {
                var response = _httpClient.PostAsJsonAsync<Product>("http://localhost:5250/api/Product", product).Result;
                Product? addedPerson = await response.Content.ReadFromJsonAsync<Product>();
                return addedPerson;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var resProduct = await AddPerson(product);
            if (resProduct == null)
            {
                isFailed = true;
                return Page();
            }
            return RedirectToPage("Index");
          
        }
    }
}
