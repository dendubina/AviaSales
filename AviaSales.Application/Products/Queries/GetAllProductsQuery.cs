using AviaSales.Domain.Entities;
using MediatR;

namespace AviaSales.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
