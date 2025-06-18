using MF.Domain.Entities;
using MF.Domain.Interfaces.Repositories;
using MF.Infrastructure.Configurations;

namespace MF.Infrastructure.Repositories
{
    public class AuthRepository: ERepository<User>, IAuthRepository
    {
        public AuthRepository(IQueryableUnitOfWork unitOfWork): base(unitOfWork)
        {
            
        }
    }
}
