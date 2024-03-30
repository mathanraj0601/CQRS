using Domain.Entity;
using Domain.Interface;

namespace DataAccess
{
    public class ProductDatabase : IProductDatabase
    {
        private List<Product> Products { get; init; }


        public ProductDatabase()
        {
              this.Products = new List<Product> {
                  new Product { Id= 1, Name= "Product 1", Price=12.0},
                  new Product { Id= 2, Name= "Product 2", Price=24.0},
                  new Product { Id= 3, Name= "Product 3", Price=36.0},
                  new Product { Id= 4, Name= "Product 4", Price=48.0},
                  new Product { Id= 5, Name= "Product 5", Price=78.0},
              };
        }

        public async Task<Product> GetProductbyId(int id)
        {
            var product = Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
                throw new Exception("Product not found");
            return await Task.FromResult(product);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Task.FromResult(Products);
        }



        public async Task<Product> DeleteProductbyId(int Id)
        {

            var product = Products.FirstOrDefault(p => p.Id == Id);
            if (product == null) throw new Exception("Product not found");
            Products.Remove(product);
            return await Task.FromResult(product);
        }

        public async Task<Product> UpdateProductbyId(int id, double price)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception("Product not found");
            product.UpdatePrice(price); 
            Products.First(p => p.Id == id).UpdatePrice(price);
            return await Task.FromResult(product);
        }

        public async Task<Product> AddProduct(string? name,Double price)
        {
            Product product = new Product
            {
                Id = Products.Max(p => p.Id) + 1,
                Name = name,
                Price = price
            };
            Products.Add(product);
            return await Task.FromResult(product);
        }

     
    }
}
