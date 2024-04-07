using Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class DeleteProductByIdCommand : IRequest<ProductResponseModel>
    {
        public int Id { get; set; }
        public DeleteProductByIdCommand(int id)
        {
            this.Id = id;
        }
    }
}
