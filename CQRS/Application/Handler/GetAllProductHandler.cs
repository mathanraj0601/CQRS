using Application.Models.ViewModel;
using Application.Query;
using Domain.Interface;
using MediatR;

namespace Application.Handler
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<ProductResponseModel>>
    {
        private readonly IProductDatabase _productDatabase;
        public GetAllProductHandler(IProductDatabase productDatabase)
        {
            _productDatabase = productDatabase;
        }
        public async Task<List<ProductResponseModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productDatabase.GetAllProducts();
            return products.Select(p => new ProductResponseModel { Name = p.Name, Price = p.Price }).ToList();
        }
    }
}
