using MF.Domain.Entities;
using MF.Domain.Interfaces.Repositories;
using MF.Infrastructure.Configurations;

namespace MF.Infrastructure.Repositories
{
    public class ElaborationTypeRepository: ERepository<ElaborationType>, IElaborationTypeRepository
    {
        public ElaborationTypeRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
