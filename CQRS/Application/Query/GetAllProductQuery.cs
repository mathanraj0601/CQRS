

using Application.Models.ViewModel;
using MediatR;

namespace Application.Query
{
    public class GetAllProductQuery : IRequest<List<ProductResponseModel>>
    {
        

    }
}
