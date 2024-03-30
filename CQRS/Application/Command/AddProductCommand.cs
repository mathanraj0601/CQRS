using Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Command
{
    public class AddProductCommand : IRequest<ProductResponseModel>
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public AddProductCommand(string? name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
