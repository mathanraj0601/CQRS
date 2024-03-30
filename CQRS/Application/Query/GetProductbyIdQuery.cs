using Application.Models.ViewModel;
using MediatR;


namespace Application.Query
{
    public class GetProductbyIdQuery : IRequest<ProductResponseModel>
    {
        public int Id { get; set; }

        public GetProductbyIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
