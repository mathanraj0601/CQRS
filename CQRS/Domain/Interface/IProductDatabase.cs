using Domain.Entity;


namespace Domain.Interface
{
    public interface IProductDatabase
    {
        public Task<Product> AddProduct(string? name, Double price);
        public Task<Product> GetProductbyId(int id);
        public Task<List<Product>> GetAllProducts();
        public Task<Product> UpdateProductbyId(int id, Double price);
        public Task<Product> DeleteProductbyId(int id);


    }
}
