using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.DTO;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context)
        {
        }


        public void CadastrarUser(string username, byte[] hash, byte[] salt)
        {
            var user = new User(username, hash, salt);
            Add(user);
            SaveChanges();
        }

        public User BuscarUserPorUsername(string username)
        {
            return Db.Users.Where(u => u.Username == username).FirstOrDefault();
        }
    }
}
