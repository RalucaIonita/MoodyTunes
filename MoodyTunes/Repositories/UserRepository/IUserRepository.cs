using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.UserRepository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int Id);
        User Create(User user);
        User Update(User user);
        User Delete(User user);
    }
}
