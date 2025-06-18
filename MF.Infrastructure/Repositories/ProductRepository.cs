using MF.Domain.Entities;
using MF.Domain.Interfaces.Repositories;
using MF.Infrastructure.Configurations;

namespace MF.Infrastructure.Repositories
{
    public class ProductRepository : ERepository<Product>, IProductRepository
    {
        public ProductRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
