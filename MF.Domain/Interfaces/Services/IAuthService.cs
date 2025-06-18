using MF.Domain.Dtos;
using MF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Interfaces.Services
{
    public interface IAuthService: IServiceBase<User, LoginUserDto>
    {
        Task<string> SignInAsync(string user, string password);
    }
}
