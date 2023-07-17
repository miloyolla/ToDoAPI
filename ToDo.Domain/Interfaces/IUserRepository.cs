using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void CadastrarUser(string username, byte[] hash, byte[] salt);
        User BuscarUserPorUsername(string username);
    }
}
