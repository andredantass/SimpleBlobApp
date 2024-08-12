using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Domain.Entities;

namespace SimpleBlogApp.Infra.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByCredentials(string nickName, string password);
    }
}
