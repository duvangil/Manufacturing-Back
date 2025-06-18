using MF.Domain.Dtos;
using MF.Domain.Entities;

namespace MF.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product, ProductDto>
    {
        Task RemoveStockAsync(Guid productId, int quantity);
    }
}
