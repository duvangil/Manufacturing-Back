using AutoMapper;
using MF.Domain.Dtos;
using MF.Domain.Entities;
using MF.Domain.Interfaces.Repositories;
using MF.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MF.Application.Services
{
    public class AuthService : Service<User, LoginUserDto>, IAuthService
    {
        public const string USER_NOT_FOUND = "User Not Found";
        public const string USER_PASWORD_INCORRECT = "User pasword incorect";
        public IConfiguration Configuration { get; }
        private readonly IPasswordHasher PasswordHasher;
        private readonly ITokenGenerator TokenGenerator;
        public AuthService(IAuthRepository authRepository, IMapper mapper, IConfiguration configuration, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator ) : base(authRepository, mapper)
        {
            Configuration = configuration;
            PasswordHasher = passwordHasher;
            TokenGenerator = tokenGenerator;    
        }

        public async Task<string> SignInAsync(string user, string password)
        {
            LoginUserDto userLogin = await FindByAlternateKeyAsync(x => x.Username == user, string.Empty);
            if (userLogin != null)
            {
                if (PasswordHasher.Verify(password, userLogin.Password))
                {
                    return TokenGenerator.GenerateToken(Configuration["JWT:Secret"],
                        Configuration["JWT:ValidIssuer"],
                        Configuration["JWT:ValidAudience"]);
                }
                else
                {
                    throw new InvalidOperationException(USER_PASWORD_INCORRECT);
                }
            }
            else
            {
                throw new ArgumentNullException(USER_NOT_FOUND);
            }
        }
    }
}
