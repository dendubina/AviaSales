using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Products.Queries;
using AviaSales.Domain.Entities;
using MediatR;

namespace AviaSales.Application.Products.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            => _productRepository.GetAllAsync();
    }
}
