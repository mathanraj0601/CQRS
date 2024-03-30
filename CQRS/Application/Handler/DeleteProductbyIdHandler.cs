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
    public class DeleteProductbyIdHandler : IRequestHandler<DeleteProductByIdCommand, ProductResponseModel>
    {
        private readonly IProductDatabase _productDatabase;
        public DeleteProductbyIdHandler(IProductDatabase productDatabase)
        {
            _productDatabase = productDatabase;
        }

        public async Task<ProductResponseModel> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product =await _productDatabase.DeleteProductbyId(request.Id);
            return new ProductResponseModel { Name = product.Name, Price = product.Price };
        }
    }
}
