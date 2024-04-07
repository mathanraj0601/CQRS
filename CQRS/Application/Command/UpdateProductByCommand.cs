using Application.Models.ViewModel;
using MediatR;

namespace Application.Command
{
    public class UpdateProductByCommand : IRequest<ProductResponseModel>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public UpdateProductByCommand(int id, double price)
        {
            this.Id = id;
            this.Price = price;
        }
    }
}
