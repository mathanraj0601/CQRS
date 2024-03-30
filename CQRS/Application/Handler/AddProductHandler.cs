using Application.Command;
using Application.Models.ViewModel;
using Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductResponseModel>
    {
        private readonly IProductDatabase _productDatabase;
        public AddProductHandler(IProductDatabase productDatabase)
        {
            this._productDatabase = productDatabase;
        }
        public async Task<ProductResponseModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productDatabase.AddProduct(request.Name, request.Price);
            return new ProductResponseModel { Name = product.Name, Price = product.Price };
        }
    }
}
