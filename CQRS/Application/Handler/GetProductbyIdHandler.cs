using Application.Models.ViewModel;
using Application.Query;
using Domain.Interface;
using MediatR;

namespace Application.Handler
{
    public class GetProductbyIdHandler : IRequestHandler<GetProductbyIdQuery, ProductResponseModel>
    {
        private readonly IProductDatabase _productDatabase;
        public GetProductbyIdHandler(IProductDatabase productDatabase)
        {
            _productDatabase = productDatabase;
        }
        public async Task<ProductResponseModel> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productDatabase.GetProductbyId(request.Id);
            return new ProductResponseModel { Name = product.Name, Price = product.Price };
        }
    }
}
