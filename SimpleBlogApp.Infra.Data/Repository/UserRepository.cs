using Microsoft.EntityFrameworkCore;
using SimpleBlogApp.Abstraction.Repository;
using SimpleBlogApp.Abstraction.Request;
using SimpleBlogApp.Domain.Entities;
using SimpleBlogApp.Infra.Data.DBContext;
using SimpleBlogApp.Infra.Data.Repository.Interfaces;

namespace SimpleBlogApp.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SimpleBlogDbContext context) : base(context)
        {
                
        }

        public async Task<User> GetByCredentials(string nickName, string password)
        =>
            await DbSet.Where(x => x.Nickname == nickName 
                                                   && x.Password == password).FirstOrDefaultAsync();
    }
}
