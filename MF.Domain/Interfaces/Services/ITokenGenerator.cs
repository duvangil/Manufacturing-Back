using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Interfaces.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(string secret, string issuer, string audience);
    }
}
