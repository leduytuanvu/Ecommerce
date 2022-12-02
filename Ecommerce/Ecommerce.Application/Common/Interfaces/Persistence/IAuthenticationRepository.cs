using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IAuthenticationRepository
    {
        Task<string?> CheckUsernameExistOrNotExist(string username);
    }
}
