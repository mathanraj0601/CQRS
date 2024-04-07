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
    public class UpdateProductByIdHandler : IRequestHandler<UpdateProductByCommand, ProductResponseModel>
    {
        private readonly IProductDatabase _productDatabase;
        public UpdateProductByIdHandler(IProductDatabase productDatabase)
        {
            _productDatabase = productDatabase;
        }

        public async Task<ProductResponseModel> Handle(UpdateProductByCommand request, CancellationToken cancellationToken)
        {
            var product = await _productDatabase.UpdateProductbyId(request.Id, request.Price);
            return new ProductResponseModel { Name = product.Name, Price = product.Price };
        }
    }
}
