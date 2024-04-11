using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;

namespace RazorPages.Pages
{
    [Authorize]
    public class ViewPersonModel : PageModel
    {

        public List<Product> products { get; set; }
        public bool isEmpty { get; set; }
        private readonly HttpClient _httpClient;
        public ViewPersonModel(HttpClient httpClient)
        {
            products = new List<Product>();
            _httpClient = httpClient;

        }
        public async void OnGet()
        {
            var products = await GetProducts();
            if (products == null || products.Count == 0)
                isEmpty =true;
            else
                this.products = products;
        }

        private  async Task<List<Product>?> GetProducts()
        {
            try
            {
                var response = _httpClient.GetAsync("http://localhost:5250/api/Product").Result;
                var products = await response.Content.ReadFromJsonAsync<List<Product>>();
                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
