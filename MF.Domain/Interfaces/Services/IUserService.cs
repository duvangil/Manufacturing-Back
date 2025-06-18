using MF.Domain.Dtos;
using MF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Interfaces.Services
{
    public interface IUserService: IServiceBase<User,UserDto>
    {
        // Aquí puedes definir métodos específicos para el servicio de usuario
        // Ejemplo:
        // Task<User> GetUserByEmailAsync(string email);
        // Task<IEnumerable<User>> GetAllUsersAsync();

    }
}
